using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lotto
{
    public partial class Form1 : Form
    {
        List<Lotto> lottoList = new List<Lotto>();
        List<int> unInsertedNumList = new List<int>();
        HtmlWeb web = new HtmlWeb(); // 
        HtmlAgilityPack.HtmlDocument htmlDoc;
        static public int newTurnNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            web.OverrideEncoding = Encoding.UTF8;
            htmlDoc = web.Load(new Uri("http://nlotto.co.kr/gameResult.do?method=byWin")); //          
            newTurnNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//option")[0].InnerText);   // 제일 최신 회차 번호 변수에 저장           

            for (int i = 1; i <= newTurnNum; i++)
            {
                cbxTurnNum.Items.Add(i);
            }

            DisplayList();
        }

        private void btnAnalyst_Click(object sender, EventArgs e)
        {
            FrmAnalysis fa = new FrmAnalysis();
            fa.ShowDialog();
        }

        private void btnReNew_Click(object sender, EventArgs e)
        {
            UpdateLotto(); // 갱신되지 않은 최신회차 가져오기
            InsertLotto(); // 최신회차까지 올라온 list 내용을 
            DisplayList();
        }

        private void InsertLotto()
        {
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                foreach (var item in lottoList)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertLotto";

                    cmd.Parameters.AddWithValue("turnnumber", item.TurnNumber);
                    cmd.Parameters.AddWithValue("num1", item.Num1);
                    cmd.Parameters.AddWithValue("num2", item.Num2);
                    cmd.Parameters.AddWithValue("num3", item.Num3);
                    cmd.Parameters.AddWithValue("num4", item.Num4);
                    cmd.Parameters.AddWithValue("num5", item.Num5);
                    cmd.Parameters.AddWithValue("num6", item.Num6);
                    cmd.Parameters.AddWithValue("bonusnum", item.BonusNum);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        private void UpdateLotto() // 로또 최근까지 업데이트뒤의 회차 ~ 최신회차를 갱신해서 list에 넣어준다.
        {
            lottoList.Clear(); // 리스트 클리어
            unInsertedNumList.Clear();
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLotto";

                SqlDataReader sdr = cmd.ExecuteReader();

                web.OverrideEncoding = Encoding.UTF8;
                htmlDoc = web.Load(new Uri("http://nlotto.co.kr/gameResult.do?method=byWin")); //          
                newTurnNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//option")[0].InnerText);   // 제일 최신 회차 번호 변수에 저장           

                int nowNum = 0;
                for (int i = 1; i <= newTurnNum; i++)
                {
                    unInsertedNumList.Add(i);
                }

                while (sdr.Read())
                {
                    nowNum = Int32.Parse(sdr["turnnumber"].ToString());

                    unInsertedNumList.Remove(nowNum);
                }

                con.Close();


                if (unInsertedNumList.Count == 0)
                {
                    UpdateProgressBar.Maximum = 1;
                    UpdateProgressBar.Value = unInsertedNumList.Count + 1;
                }
                else
                {
                    UpdateProgressBar.Maximum = unInsertedNumList.Count;
                }

                foreach (var item in unInsertedNumList)
                {
                    UpdateProgressBar.Value += 1;
                    htmlDoc = web.Load(new Uri("http://nlotto.co.kr/gameResult.do?method=byWin&drwNo=" + item.ToString()));
                    Parsing(htmlDoc);
                }
            }
        }

        private void Parsing(HtmlAgilityPack.HtmlDocument htmlDoc) // 원하는 회차를 파싱해서 로또 객체에 저장후 List에 넣어줌
        {
            string[] temp = new string[6];
            Lotto lotto = new Lotto();
            foreach (var item in htmlDoc.DocumentNode.SelectNodes("//body//p"))
            {
                if (item.GetAttributeValue("class", "") == "number")
                {
                    int i = 0;
                    foreach (var item2 in item.ChildNodes)
                    {
                        if (item2.Name == "img")
                        {
                            temp[i] = item2.Attributes["alt"].Value;
                            i++;
                        }
                        foreach (var item3 in item2.ChildNodes)
                        {
                            if (item3.Name == "img")
                            {
                                lotto.BonusNum = Int32.Parse(item3.Attributes["alt"].Value);
                            }
                        }
                    }
                }
            }

            foreach (var item in htmlDoc.DocumentNode.SelectNodes("//body//h3//strong"))
            {
                lotto.TurnNumber = Int32.Parse(item.InnerText);
            }

            lotto.Num1 = Int32.Parse(temp[0]);
            lotto.Num2 = Int32.Parse(temp[1]);
            lotto.Num3 = Int32.Parse(temp[2]);
            lotto.Num4 = Int32.Parse(temp[3]);
            lotto.Num5 = Int32.Parse(temp[4]);
            lotto.Num6 = Int32.Parse(temp[5]);
            lottoList.Add(lotto);
        }

        private void DisplayList() // LottoDB에서 전체 내용을 가져와 List에 저장후 DataGridView에 보여준다
        {
            lottoList.Clear();
            LottoGridView.Columns.Clear();
            LottoGridView.DataSource = null;

            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLotto";

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Lotto lotto = new Lotto(Int32.Parse(sdr["turnnumber"].ToString()), Int32.Parse(sdr["num1"].ToString()), Int32.Parse(sdr["num2"].ToString()), Int32.Parse(sdr["num3"].ToString()), Int32.Parse(sdr["num4"].ToString()), Int32.Parse(sdr["num5"].ToString()), Int32.Parse(sdr["num6"].ToString()), Int32.Parse(sdr["bonusnum"].ToString()));

                    lottoList.Add(lotto); // 

                    lblCurrentLottoNum.Text = lotto.TurnNumber + "회차 : " + lotto.Num1 + " " + lotto.Num2 + " " + lotto.Num3 + " " + lotto.Num4 + " " + lotto.Num5 + " " + lotto.Num6 + " 보너스 번호 : " + lotto.BonusNum + "";
                }
            }
            LottoGridView.DataSource = lottoList;

            LottoGridView.Columns[0].HeaderText = "회차";
            LottoGridView.Columns[1].HeaderText = "1구";
            LottoGridView.Columns[2].HeaderText = "2구";
            LottoGridView.Columns[3].HeaderText = "3구";
            LottoGridView.Columns[4].HeaderText = "4구";
            LottoGridView.Columns[5].HeaderText = "5구";
            LottoGridView.Columns[6].HeaderText = "6구";
            LottoGridView.Columns[7].HeaderText = "보너스구";

            LottoGridView.Sort(LottoGridView.Columns[0], ListSortDirection.Ascending);
            //LottoGridView.Columns["TurnNumber"].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(cbxTurnNum.Text) <= newTurnNum && cbxTurnNum.Text != null)
                {
                    LottoGridView.DataSource = null;
                    LottoGridView.Columns.Clear();
                    foreach (Lotto item in lottoList)
                    {
                        if (cbxTurnNum.Text.ToString().Equals(item.TurnNumber.ToString()))
                        {
                            string[] s = { item.TurnNumber.ToString(), item.Num1.ToString(), item.Num2.ToString(), item.Num3.ToString(), item.Num4.ToString(), item.Num5.ToString(), item.Num6.ToString(), item.BonusNum.ToString() };
                            LottoGridView.Columns.Add("turnnumber", "회차");
                            LottoGridView.Columns.Add("num1", "1구");
                            LottoGridView.Columns.Add("num2", "2구");
                            LottoGridView.Columns.Add("num3", "3구");
                            LottoGridView.Columns.Add("num4", "4구");
                            LottoGridView.Columns.Add("num5", "5구");
                            LottoGridView.Columns.Add("num6", "6구");
                            LottoGridView.Columns.Add("bonusnum", "보너스구");
                            LottoGridView.Rows.Add(s);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("회차를 입력해 주세요");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("숫자를 입력해 주세요");
            }
            
            //LottoGridView.Rows[0].Cells[0].Style.BackColor = Color.Yellow;
            
            //if (cbxTurnNum.SelectedIndex != -1) // 콤보박스가 선택되었을경우에만 실행
            //{
            //    // 선택된 row의 cell collection을 가져와 선택을 해준다.
            //    foreach (DataGridViewCell tt in LottoGridView.Rows[Int32.Parse(cbxTurnNum.SelectedItem.ToString()) - 1].Cells)
            //    {
            //        tt.Style.BackColor = Color.Yellow; // 선택된 row의 cell들 전체를 칼라로 칠해준다.
            //    }

            //    // 스크롤바의 위치를 선택된 row의 값으로 이동해준다.
            //    LottoGridView.FirstDisplayedScrollingRowIndex = Int32.Parse(cbxTurnNum.SelectedItem.ToString()) - 1;
            //}
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            DisplayList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmTest().Show();
        }
    }
}
