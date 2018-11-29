using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private int newTurnNum;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HtmlWeb web = new HtmlWeb(); // 
            web.OverrideEncoding = Encoding.UTF8;
            HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(new Uri("http://nlotto.co.kr/gameResult.do?method=byWin")); //
            

            newTurnNum = Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//body//option")[0].InnerText);   // 제일 최신 회차 찾기

            for (int i = 1; i <= 10; i++)
            {
                htmlDoc = web.Load(new Uri("http://nlotto.co.kr/gameResult.do?method=byWin&drwNo=" + i));

                Parsing(htmlDoc);
            }

            DisplayList();
        }

        private void DisplayList()
        {
            foreach (var item in lottoList)
            {
                txtHtml.Text += item.TurnNumber + "회차 : " + item.Num1 + ", " + item.Num2 + ", " + item.Num3 + ", " + item.Num4 + ", " + item.Num5 + ", " + item.Num6 + ", " + "보너스 :" + item.BonusNum + "\r\n";
            }
        }

        private void Parsing(HtmlAgilityPack.HtmlDocument htmlDoc)
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

        private void btnAnalyst_Click(object sender, EventArgs e)
        {
            FrmAnalysis fa = new FrmAnalysis();
            fa.ShowDialog();
        }
    }
}
