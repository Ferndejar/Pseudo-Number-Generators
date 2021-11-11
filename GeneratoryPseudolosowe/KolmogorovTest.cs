using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;

namespace GeneratoryPseudolosowe
{
    class KolmogorovTest
    {
        public int quanity { get; set; }
        public float[] tab { get; set; }

        public float pamOne { get; set; }
        public float pamTwo { get; set; }


        public KolmogorovTest(int ilosc,  float[] tabValue)
        {
            this.quanity = ilosc;
            this.tab = tabValue;
        }

       public float statystykaKolmogorowa(int ilosc, float[] tabValue,float pamOne, float pamTwo, string checkS)
        {
            float max = 0;
            var tabSort = new float[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                tabSort[i] = tabValue[i];
            }
            Array.Sort(tabSort);
            float howMany = (float) ilosc; 

            if (checkS == "JS")
            {
                var jedS = new UniformContinuousDistribution(0, 1);
                for (int i = 0; i < howMany; i++)
                {

                    if (Math.Abs(jedS.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(jedS.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(jedS.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float) Math.Abs(jedS.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                      
                    }
                    else if (Math.Abs(jedS.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                    {
                        max = (float)Math.Abs(jedS.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                    }
                }
            }
            else if (checkS == "J")
            {
                var jedS = new UniformContinuousDistribution(pamOne, pamTwo);
                for (int i = 0; i < ilosc; i++)
                {

                    if (Math.Abs(jedS.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(jedS.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(jedS.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float)Math.Abs(jedS.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                        else if (Math.Abs(jedS.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                        {
                            max = (float)Math.Abs(jedS.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                        }
                    }
                }
            }
            else if (checkS == "Exp")
            {
                var exp = new ExponentialDistribution(pamOne);
                for (int i = 0; i < ilosc; i++)
                {

                    if (Math.Abs(exp.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(exp.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(exp.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float)Math.Abs(exp.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                        else if (Math.Abs(exp.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                        {
                            max = (float)Math.Abs(exp.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                        }
                    }
                }
            }
            else if (checkS == "NomS")
            {
                var nom = new NormalDistribution(0,1);
                for (int i = 0; i < ilosc; i++)
                {

                    if (Math.Abs(nom.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(nom.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(nom.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float)Math.Abs(nom.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                        else if (Math.Abs(nom.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                        {
                            max = (float)Math.Abs(nom.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                        }
                    }
                }
            }
            else if (checkS == "Nom")
            {
                var nom = new NormalDistribution(pamOne, pamTwo);
                for (int i = 0; i < ilosc; i++)
                {

                    if (Math.Abs(nom.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(nom.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(nom.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float)Math.Abs(nom.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                        else if (Math.Abs(nom.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                        {
                            max = (float)Math.Abs(nom.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                        }
                    }
                }
            }
            else if (checkS == "Chi")
            {
                var chi = new ChiSquareDistribution((int)pamOne);
                for (int i = 0; i < ilosc; i++)
                {

                    if (Math.Abs(chi.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(chi.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(chi.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float)Math.Abs(chi.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                        else if (Math.Abs(chi.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                        {
                            max = (float)Math.Abs(chi.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                        }
                    }
                }
            }
            else if (checkS == "Tstudent")
            {
                var tst = new TDistribution(pamOne);
                for (int i = 0; i < ilosc; i++)
                {

                    if (Math.Abs(tst.DistributionFunction(tabSort[i]) - i / howMany) >
                        Math.Abs(tst.DistributionFunction(tabSort[i]) - (i + 1) / howMany))
                    {
                        if (Math.Abs(tst.DistributionFunction(tabSort[i]) - i / howMany) > max)
                        {
                            max = (float)Math.Abs(tst.DistributionFunction(tabSort[i]) - i / howMany);
                        }
                        else if (Math.Abs(tst.DistributionFunction(tabSort[i]) - (i + 1) / howMany) > max)
                        {
                            max = (float)Math.Abs(tst.DistributionFunction(tabSort[i]) - (i + 1) / howMany);
                        }
                    }
                }
            }

           // return max * (float) Math.Sqrt(ilosc);
           return max;
        }

        public float TQuantile(int ilosc, float levelOfDegree)
        {
            float S = 1-levelOfDegree;
            int freedoomDegree = ilosc;

            var kol = new KolmogorovSmirnovDistribution(freedoomDegree);
            float result = (float)kol.InverseDistributionFunction(S);

            return result;
        }
    }
}
