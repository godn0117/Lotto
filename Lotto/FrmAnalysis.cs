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
    public partial class FrmAnalysis : Form
    {
        public FrmAnalysis()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmLotteryPick flp = new FrmLotteryPick();
            flp.MdiParent = this;
            flp.Show();
        }

        //폼 한개만 띄우기
        private Chart frmChart;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!(frmChart == null || !frmChart.Visible))
            {
                frmChart.Focus();
                return;
            }
            frmChart = new Chart();
            frmChart.Show();
        }
    }
}
