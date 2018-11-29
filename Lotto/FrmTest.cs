using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            int num = 1;
            DataTable dt = new DataTable();

            for (int i = 0; i < 7; i++)
            {
                DataColumn column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");

                //column.DefaultValue = num++;

                // Add the column to the table. 
                dt.Columns.Add(column);

                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    dt.Rows[i][j] = num++;
                    if (num == 46)
                    {
                        break;
                    }
                }

            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = dt;


            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SelectLotto";

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    this.cboTurn.Items.Add(Int32.Parse(dr[0].ToString()));
                }
                dr.Close();
                con.Close();
            }
            // 당첨 표시 예시
            // 1, 4, 
            //dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.Red;
            //int num1 = 35;
            //if ((num1 % 7) == 0)
            //{
            //    dataGridView1.Rows[(num1 / 7)-1].Cells[(num1 % 7) +6].Style.BackColor = Color.Red;
            //}
            //else {
            //    dataGridView1.Rows[num1 / 7].Cells[(num1 % 7) - 1].Style.BackColor = Color.Red;
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {//당첨번호 표시
         //예외처리 -> 수정중
            //if (Int32.Parse(this.cboTurn.Text))
            //{

            //}

            //표시 초기화
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                foreach (DataGridViewCell item2 in item.Cells)
                {
                    item2.Style.BackColor = Color.White;
                }
            }
            using (SqlConnection con = DBConnection.Connecting())
            {
                con.Open();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "SelectTurn";

                com.Parameters.AddWithValue("turnnumber", Int32.Parse(this.cboTurn.Text));

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 1; i < dr.FieldCount - 1; i++)
                    {
                        int number = Int32.Parse(dr[i].ToString());
                        if (number % 7 == 0)
                        {
                            dataGridView1.Rows[(number / 7) - 1].Cells[(number % 7) + 6].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[number / 7].Cells[(number % 7) - 1].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
    }
}
