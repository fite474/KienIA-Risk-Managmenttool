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

        private int HazardLevelSil(int seValue, int clValue)
        {
            int colorValue = 1;//1 = green, 10 = yellow, 100 = red
            int restRiskValue = seValue * clValue;
            switch (seValue)
            {
                case 1:
                    if (3 <= clValue && clValue <= 4)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs: " + restRiskValue.ToString());

                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    break;
                case 2:
                    if (3 <= clValue && clValue <= 4)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)
                    {
                        Console.WriteLine("wit: " + restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs: " + restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    
                    break;
                case 3:
                    if (3 <= clValue && clValue <= 4)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs" + restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    
                    break;
                case 4:
                    if (3 <= clValue && clValue <= 4)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs: " + restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    
                    break;
                default:
                    break;
            }
            return colorValue;//restRiskValue;
        }

        public Tuple<int, int> CalculateSilMode(int se, int fr, int pr, int av)
        {
            //the sum of Fr, Pr and Av, i.e. Cl = Fr + Pr + Av

            //se 1 tm 4
            //fr 2 tm 6
            //pr 1 tm 5
            //av 1, 3, 5




            int cl = (fr + pr + av);
            int risk = HazardLevelSil(se, cl);
            return new Tuple<int, int>(cl, risk);
        }

        private int HazardLevelPl(int seValue, int clValue)
        {
            int colorValue = 1;//1 = green, 10 = yellow, 100 = red
            int restRiskValue = seValue * clValue;
            switch (seValue)
            {
                case 1:
                    if (3 <= clValue && clValue <= 4)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs: " + restRiskValue.ToString());

                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    break;
                case 2:
                    if (3 <= clValue && clValue <= 4)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)
                    {
                        Console.WriteLine("wit: " + restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs: " + restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }

                    break;
                case 3:
                    if (3 <= clValue && clValue <= 4)
                    {
                        Console.WriteLine(restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs" + restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }

                    break;
                case 4:
                    if (3 <= clValue && clValue <= 4)//grijs
                    {
                        colorValue = 10;
                        Console.WriteLine("grijs: " + restRiskValue.ToString());
                    }
                    else if (5 <= clValue && clValue <= 7)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (8 <= clValue && clValue <= 10)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (11 <= clValue && clValue <= 13)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }
                    else if (14 <= clValue && clValue <= 15)//zwart
                    {
                        colorValue = 100;
                        Console.WriteLine("zwart: " + restRiskValue.ToString());
                    }

                    break;
                default:
                    break;
            }
            return colorValue;//restRiskValue;
        }





        public Tuple<int, int> CalculatePlMode(int se, int fr, int pr, int av)
        {
            //Risk assessment using risk graph figuur a.3




            //start : severity S1 = slightly, S2 = serious

            //S1 -> exposure F1, F2 geen verschil 

            //s1 -> probability of exposure o1, o2 -> A1, a2 = 1
            //s1 -> prob o3,  = A1, a2 = 2


            //----------------------------------------
            //s2 -> F1 seldom, f2 frequent
            //f1 -> o1 -> a1, a2 = 2
            //f1 -> o2 + a1 = 2.     o2 + a2 = 3
            //f1 -> o3 + a1 = 3.     o3 + a2 = 4



            //f2 _> o1 + a1 = 3      o1 + a2 = 4
            //f2 -> o2 + a1 = 4     o2 + a2 = 5
            //f2 -> o3 + a1 = 5     o3 + a2 = 6

            //1 2 ok
            //3 4 kinda
            //5 6 bad
            int clValue = 1;

            if (se == 1)
            {
                if (fr == 1 || fr == 2)
                {
                    if (pr == 1 || pr == 2)
                    {
                        if (av == 1 || av == 2)
                        {
                            clValue = 1;
                        }
                    }
                    else if (pr == 3)
                    {
                        if (av == 1 || av == 2)
                        {
                            clValue = 2;
                        }
                    }
                }
            }
            else if (se == 2)
            {
                if (fr == 1)
                {
                    if (pr == 1)
                    {
                        if (av == 1 || av == 2)
                        {
                            clValue = 2;
                        }
                    }
                    else if (pr == 2)
                    {
                        if (av == 1)
                        {
                            clValue = 2;
                        }
                        else if (av == 2)
                        {
                            clValue = 3;
                        }
                    }
                    else if (pr == 3)
                    {
                        if (av == 1)
                        {
                            clValue = 3;
                        }
                        else if (av == 2)
                        {
                            clValue = 4;
                        }
                    }

                }
                else if (fr == 2)
                {
                    if (pr == 1)
                    {
                        if (av == 1)
                        {
                            clValue = 3;
                        }
                        else if (av == 2)
                        {
                            clValue = 4;
                        }
                    }
                    else if (pr == 2)
                    {
                        if (av == 1)
                        {
                            clValue = 4;
                        }
                        else if (av == 2)
                        {
                            clValue = 5;
                        }
                    }
                    else if (pr == 3)
                    {
                        if (av == 1)
                        {
                            clValue = 5;
                        }
                        else if (av == 2)
                        {
                            clValue = 6;
                        }
                    }

                }
            }

            int risk = 0;//HazardLevelPl(se, cl);//(fr + pr + av);
            if (clValue == 1 || clValue == 2)
            {
                risk = 1;
            }
            else if (clValue == 3 || clValue == 4)
            {
                risk = 10;
            }
            else if (clValue == 5 || clValue == 6)
            {
                risk = 100;
            }


            return new Tuple<int, int>(clValue, risk);
        }
    }
}
