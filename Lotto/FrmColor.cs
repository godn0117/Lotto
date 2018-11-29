using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lotto
{
    public partial class FrmColor : Form
    {
        // 번호별 통계를 담을 리스트

        public FrmColor()
        {
            InitializeComponent();
        }

        // 조회버튼 클릭
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int startNum = Int32.Parse(this.cboSta.Text);
            int endNum = Int32.Parse(this.cboEnd.Text);
            if (startNum > endNum)
            {
                MessageBox.Show("앞자리 숫자가 뒤자리 숫자보다 클수 없습니다.");
                return;
            }

            
            
        }

        private void FrmColor_Load(object sender, EventArgs e)
        {
            this.myChart.Titles.Add("Title");
            this.myChart.Titles[0].Text = "색상 통계";

            myChart.Series[0].ChartType = SeriesChartType.Pie;
        }
    }
}
