using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Controls;
using Accord.Statistics.Distributions.Univariate;
namespace GeneratoryPseudolosowe
{
    class PearsonTest : HelpingMethods
    {
        public int quanity { get; set; }
        public float[] tab { get; set; }
      
        public float[] tabE { get; set; }
        public int quanityE { get; set; }
        public float pamOne { get; set; }
        public float pamTwo { get; set; }


        public PearsonTest(int ilosc, float[] tabEdges, int iloscBrzegi, float[] tabValue)
        {
            this.quanity = ilosc;
            this.tabE = tabEdges;
            this.tab = tabValue;
            this.quanityE = iloscBrzegi;
        }

        public int[] licznoscKlas(int ilosc, float[] tabValue, int iloscBrzegi, float[] tabEdges)
        {
            var tab_lk = new int[iloscBrzegi+1];

            for (int i = 0; i < iloscBrzegi + 1; i++)
            {
                tab_lk[i] = 0;
            }

            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] <= tabEdges[0])
                {
                    tab_lk[0]++;
                }
                else if (tabValue[i] > tabEdges[iloscBrzegi - 1])
                {
                    tab_lk[iloscBrzegi]++;
                }

                for (int j = 1; j < iloscBrzegi; j++)
                {
                    if (tabValue[i] <= tabEdges[j] && tabValue[i] > tabEdges[j - 1])
                    {
                        tab_lk[j]++;
                    }
                }
            }

            return tab_lk;
        }

        public float[] licznoscTeoretycznaJedStan(int ilosc, int iloscBrzegi, float[] tabEdges)
        {
            var tab_teor = new float[iloscBrzegi + 1];

            tab_teor[0] = ilosc * tabEdges[0];
            tab_teor[iloscBrzegi] = ilosc * (1 - tabEdges[iloscBrzegi - 1]);

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (tabEdges[i] - tabEdges[i - 1]);
            }
           

            return tab_teor;
        }

        public float[] licznoscTeoretycznaJed(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne, float pamTwo)
        {
            var tab_teor = new float[iloscBrzegi + 1];

            tab_teor[0] = ilosc * (tabEdges[0]-pamOne)/(pamTwo-pamOne);
            tab_teor[iloscBrzegi] = ilosc * (1 - (tabEdges[iloscBrzegi - 1]-pamOne) / (pamTwo - pamOne));

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (tabEdges[i] - tabEdges[i - 1])/ (pamTwo - pamOne);
            }


            return tab_teor;
        }

        public float[] licznoscTeoretycznaExp(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne)
        {
            var tab_teor = new float[iloscBrzegi + 1];

            tab_teor[0] = ilosc * (1-(float)Math.Exp(-pamOne*tabEdges[0]));
            tab_teor[iloscBrzegi] = ilosc *(float)Math.Exp(-pamOne * tabEdges[iloscBrzegi-1]);

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * ((float)Math.Exp(-pamOne * tabEdges[i-1])- (float)Math.Exp(-pamOne * tabEdges[i]));
            }


            return tab_teor;
        }

        public float[] licznoscTeoretycznaNomSt(int ilosc, int iloscBrzegi, float[] tabEdges)
        {
            var tab_teor = new float[iloscBrzegi + 1];
            var nom = new NormalDistribution(0,1);

            tab_teor[0] = ilosc * (float) nom.DistributionFunction(tabEdges[0]);
            tab_teor[iloscBrzegi] = ilosc * (1-(float)nom.DistributionFunction(tabEdges[iloscBrzegi-1]));

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (float)nom.DistributionFunction(tabEdges[i]) - (float)nom.DistributionFunction(tabEdges[i - 1]);
            }


            return tab_teor;
        }

        public float[] licznoscTeoretycznaNom(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne,float pamTwo)
        {
            var tab_teor = new float[iloscBrzegi + 1];
            var nom = new NormalDistribution(pamOne, pamTwo);

            tab_teor[0] = ilosc * (float)nom.DistributionFunction(tabEdges[0]);
            tab_teor[iloscBrzegi] = ilosc * (1 - (float)nom.DistributionFunction(tabEdges[iloscBrzegi - 1]));

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (float)nom.DistributionFunction(tabEdges[i]) - (float)nom.DistributionFunction(tabEdges[i - 1]);
            }


            return tab_teor;
        }

        public float[] licznoscTeoretycznaChiQ(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne)
        {
            var tab_teor = new float[iloscBrzegi + 1];
            var chiq = new ChiSquareDistribution((int) pamOne);

            tab_teor[0] = ilosc * (float)chiq.DistributionFunction(tabEdges[0]);
            tab_teor[iloscBrzegi] = ilosc * (1 - (float)chiq.DistributionFunction(tabEdges[iloscBrzegi - 1]));

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (float)chiq.DistributionFunction(tabEdges[i]) - (float)chiq.DistributionFunction(tabEdges[i - 1]);
            }


            return tab_teor;
        }

        public float[] licznoscTeoretycznaTStudent(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne)
        {
            var tab_teor = new float[iloscBrzegi + 1];
           
            var tsd = new TDistribution(pamOne);

            tab_teor[0] = ilosc * (float)tsd.DistributionFunction(tabEdges[0]);
            tab_teor[iloscBrzegi] = ilosc * (1 - (float)tsd.DistributionFunction(tabEdges[iloscBrzegi - 1]));

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (float)tsd.DistributionFunction(tabEdges[i]) - (float)tsd.DistributionFunction(tabEdges[i - 1]);
            }

            return tab_teor;
        }

        public float[] licznoscTeoretycznaJedDys(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne)
        {
            var tab_teor = new float[iloscBrzegi + 1];

            tab_teor[0] = ((int)tabEdges[0] * ilosc)/pamOne;
            // tab_teor[iloscBrzegi] = (pamOne-(int)tabEdges[iloscBrzegi])*ilosc;
            tab_teor[iloscBrzegi] = (pamOne- (int)tabEdges[iloscBrzegi-1])*ilosc/pamOne;

            for (int i = 1; i < iloscBrzegi; i++)
            {
                // tab_teor[iloscBrzegi] = ilosc * ((int)tabEdges[i] - (int)tabEdges[i - 1]);
                tab_teor[i] = ilosc * (tabEdges[i] - tabEdges[i - 1])/pamOne;
            }

            return tab_teor;
        }

        public float[] licznoscTeoretycznaZeroOne(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne)
        {
            var tab_teor = new float[2];

            tab_teor[0] = ilosc * (1 - pamOne);
            tab_teor[1] = ilosc * pamOne;

            return tab_teor;
        }


        public float[] licznoscTeoretycznaBernoulli(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne, float pamTwo)
        {
            var tab_teor = new float[iloscBrzegi + 1];
            var tabp = new float[(int)pamOne + 1];
            var tabd = new float[(int)pamOne + 1];

            for (int i = 0; i <= pamOne; i++)
            {
                tabp[i] = Newton((int) pamOne, i) * (float) Math.Pow(pamTwo, i) * (float) Math.Pow(1 - pamTwo, pamOne - i);
            }

            tabd[0] = tabp[0];

            for (int i = 1; i <= pamOne; i++)
            {
                tabd[i] = tabd[i - 1] + tabp[i];
            }

            tab_teor[0] = tabd[(int)tabEdges[0]] * ilosc;

            tab_teor[iloscBrzegi] = ilosc * (1 - tabd[(int) tabEdges[iloscBrzegi - 1]]);

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (tabd[(int)tabEdges[i]] - tabd[(int)tabEdges[i - 1]]);
            }

            return tab_teor;
        }



        public float[] licznoscTeoretycznaPoisson(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne, float pamTwo)
        {
            var tab_teor = new float[iloscBrzegi + 1];
            var tabp = new float[(int)pamTwo + 1];
            var tabd = new float[(int)pamTwo + 1];
            int fact = 1;

            for (int i = 0; i <= pamTwo-1; i++)
            {
                if (i == 0)
                {
                    fact = 1;
                    tabp[i] = (float)(Math.Pow(pamOne, i) / fact) * (float)Math.Exp(-pamOne);
                }
                else
                {
                    fact = factorial(i);
                    tabp[i] = (float)(Math.Pow(pamOne, i) / fact) * (float)Math.Exp(-pamOne);
                }
            }

            tabd[0] = tabp[0];

            for (int i = 1; i <= pamTwo-1; i++)
            {
                tabd[i] = tabd[i - 1] + tabp[i];
            }

            tabd[(int)pamTwo] = 1;

            tab_teor[0] = tabd[(int)tabEdges[0]] * ilosc;

            tab_teor[iloscBrzegi] = ilosc * (1 - tabd[(int)tabEdges[iloscBrzegi - 1]]);

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (tabd[(int)tabEdges[i]] - tabd[(int)tabEdges[i - 1]]);
            }

            return tab_teor;
        }

        public float[] licznoscTeoretycznaGeo(int ilosc, int iloscBrzegi, float[] tabEdges, float pamOne, float pamTwo)
        {
            var tab_teor = new float[iloscBrzegi + 1];
            var tabp = new float[(int)pamTwo + 1];
            var tabd = new float[(int)pamTwo + 1];
            int fact = 1;

            for (int i = 1; i <= pamTwo ; i++)
            {
                tabp[i - 1] = (pamOne) * (float) Math.Pow(1 - pamOne, i - 1);
            }

            tabd[0] = tabp[0];

            for (int i = 1; i <= pamTwo - 1; i++)
            {
                tabd[i] = tabd[i - 1] + tabp[i];
            }

            tabd[(int)pamTwo] = 1;

            tab_teor[0] = tabd[(int)tabEdges[0]-1] * ilosc;

            tab_teor[iloscBrzegi] = ilosc * (1 - tabd[(int)tabEdges[iloscBrzegi - 1]-1]);

            for (int i = 1; i < iloscBrzegi; i++)
            {
                tab_teor[i] = ilosc * (tabd[(int)tabEdges[i]-1] - tabd[(int)tabEdges[i - 1]-1]);
            }

            return tab_teor;
        }

        public float statystykaTestowaPearson(int iloscBrzegi, float[] tabTeor, int[] tabPract)
        {
            float S=0;

            for (int i = 0; i <= iloscBrzegi; i++)
            {
                S = S +  ((float) Math.Pow(tabTeor[i] - tabPract[i], 2)) / (tabTeor[i]);
            }

            return S;
        }

        public float Kwantyl(int iloscBrzegi, float levelOfDegree)
        {
            float S = 1 - levelOfDegree;
            int freedoomDegree = iloscBrzegi;

            var chi = new ChiSquareDistribution(freedoomDegree);
            float result = (float) chi.InverseDistributionFunction(S);

            return result;
        }

    }

}

