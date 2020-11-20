using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer
{
    class Risicograaf
    {
        public Risicograaf()
        {

        }

        private int HazardLevel(int seValue, int clValue)
        {
            int i = 0;
            switch (seValue)
            {
                case 1:
                    i = 1;
                    break;
                case 2:
                    i = 10;
                    break;
                case 3:
                    i = 100;
                    break;
                case 4:
                    i = 1000;
                    break;
                default:
                    break;
            }
            return i;
        }

        public Tuple<int, int> CalculateSilMode(int se, int fr, int pr, int av)
        {
            //the sum of Fr, Pr and Av, i.e. Cl = Fr + Pr + Av



            int cl = (fr + pr + av);
            int risk = HazardLevel(se, cl);
            return new Tuple<int, int>(cl, risk);
        }

        public void CalculatePlMode()
        {

        }
    }
}
