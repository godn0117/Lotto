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
    }
}
