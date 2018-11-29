using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Lotto
    {
        private int turnNumber;
        private int num1;
        private int num2;
        private int num3;
        private int num4;
        private int num5;
        private int num6;
        private int bonusNum;

        public Lotto()
        {

        }

        public Lotto(int turnNumber, int num1, int num2, int num3, int num4, int num5, int num6, int bonusNum)
        {
            this.turnNumber = turnNumber;
            this.num1 = num1;
            this.num2 = num2;
            this.num3 = num3;
            this.num4 = num4;
            this.num5 = num5;
            this.num6 = num6;
            this.bonusNum = bonusNum;
        }

        #region Property
        public int TurnNumber
        {
            get { return turnNumber; }
            set { turnNumber = value; }
        }

        public int Num1
        {
            get { return num1; }
            set { num1 = value; }
        }

        public int Num2
        {
            get { return num2; }
            set { num2 = value; }
        }

        public int Num3
        {
            get { return num3; }
            set { num3 = value; }
        }

        public int Num4
        {
            get { return num4; }
            set { num4 = value; }
        }

        public int Num5
        {
            get { return num5; }
            set { num5 = value; }
        }

        public int Num6
        {
            get { return num6; }
            set { num6 = value; }
        }

        public int BonusNum
        {
            get { return bonusNum; }
            set { bonusNum = value; }
        } 
        #endregion
    }
}
