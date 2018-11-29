using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                    if(num == 46)
                    {
                        break;
                    }
                }

            }
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = dt;

            // 1, 4, 
            dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.Red;

            //MessageBox.Show((43/7).ToString());
            int num1 = 35;
            if ((num1 % 7) == 0)
            {
                dataGridView1.Rows[(num1 / 7)-1].Cells[(num1 % 7) +6].Style.BackColor = Color.Red;
            }
            else {
                dataGridView1.Rows[num1 / 7].Cells[(num1 % 7) - 1].Style.BackColor = Color.Red;
            }
            

        }
    }
}
