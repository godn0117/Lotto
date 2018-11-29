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
