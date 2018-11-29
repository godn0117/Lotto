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
        HtmlWeb web = new HtmlWeb(); // 
        HtmlAgilityPack.HtmlDocument htmlDoc;
        private int newTurnNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

                int lastTurnNumber = 1;
                UpdateProgressBar.Maximum = 0;
                if (sdr == null)
                {
                    UpdateProgressBar.Maximum = newTurnNum - 0;
                }                

                while (sdr.Read())
                {
                    lastTurnNumber = Int32.Parse(sdr["turnnumber"].ToString()) + 1;
                }
                con.Close();
                
                UpdateProgressBar.Value = 0;

                for (int i = lastTurnNumber; i <= newTurnNum; i++)
                {
                    if (UpdateProgressBar.Value != UpdateProgressBar.Maximum)
                    {
                        UpdateProgressBar.Value = (int)Math.Truncate((double)newTurnNum-i/UpdateProgressBar.Maximum*100);
                    }
                    
                    htmlDoc = web.Load(new Uri("http://nlotto.co.kr/gameResult.do?method=byWin&drwNo=" + i));
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

        private void DisplayList()
        {
            lottoList.Clear();
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

                    lottoList.Add(lotto);
                }
            }

            LottoGridView.DataSource = lottoList;
        }
    }
}
