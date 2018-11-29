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
    public partial class FrmLotteryPick : Form
    {
        List<CheckBox> checkboxList = new List<CheckBox>();
        int count = 0;
        int autoCount = 6;
        public FrmLotteryPick()
        {
            InitializeComponent();
        }
        
        private void FrmLotteryPick_Load(object sender, EventArgs e)
        {
            lblCount.Text = count.ToString();
            
            foreach (Control item in groupBox1.Controls)
            {
                string autoChk;
                for (int i = 1; i < 45; i++)
                {
                    autoChk = "chk" + i.ToString();

                    if (item.Name.Equals(autoChk))
                    {
                        checkboxList.Add((CheckBox)item);
                    }
                }                
            }           
        }

        private void CheckCount(object sender)
        {
            CheckBox s = (CheckBox)sender;
            if (s.Checked)
            {
                count++;
            }
            else
            {
                count--;
            }

            lblCount.Text = count.ToString();
        }

        private void RefrainChange(object sender)
        {
            CheckBox s = (CheckBox)sender;
            if (count > 6)
            {
                MessageBox.Show("6까지만 선택 가능 합니다");
                s.Checked = false;
            }
        }

        #region CheckedEvent
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk7_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk8_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk9_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk10_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk11_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk12_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk13_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk14_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk15_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk16_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk17_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk18_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk19_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk20_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk21_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk22_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk23_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk24_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk25_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk26_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk27_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk28_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk29_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk30_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk31_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk32_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk33_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk34_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk35_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk36_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk37_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk38_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk39_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk40_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk41_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk42_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk43_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk44_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }

        private void chk45_CheckedChanged(object sender, EventArgs e)
        {
            CheckCount(sender);
            RefrainChange(sender);
        }
        #endregion

        private void btnAuto_Click(object sender, EventArgs e)
        {
            autoCount = 6 - count;

            Random rand = new Random();
            for (int i = 0; i < autoCount; i++)
            {
                string autoChk = "chk" + rand.Next(1, 45).ToString();
                foreach (Control item in groupBox1.Controls)
                {
                    if (item.Name == autoChk)
                    {
                        CheckBox c = (CheckBox)item;
                        if (c.Checked)
                        {
                            i--;
                        }
                        else
                        {
                            c.Checked = true;
                        }
                    }
                }
            }            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (CheckBox item in checkboxList)
            {
                item.Checked = false;
            }            
        }
    }
}
