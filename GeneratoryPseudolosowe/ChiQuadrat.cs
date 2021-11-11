using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class ChiQuadrat
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public ChiQuadrat(int ilosc, float Pa,  float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.tab = tabValue;

        }

        public ChiQuadrat(int ilosc, float Pa, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.tabD = tabValue;

        }


        public float[] chikwadrat(int ilosc, float pOne, float[] tabValue)
        {
            Normal nom = new Normal(ilosc,tabValue);
            int k = (int) pOne;

          //  tabValue = nom.normalnyStandardowy(ilosc*k, tabValue);
           var tab = new float[ilosc*k];
            for (int i = 0; i < ilosc * k; i++)
            {
                if (i < ilosc)
                {
                    tab[i] = tabValue[i];
                }
                else
                {
                    tab[i] = 0f;
                }
            }
            tab = nom.normalnyStandardowy(ilosc*k, tab);

            var tab2 = new float[ilosc];

            for (int i = 0; i < ilosc; i=i+k)
            {
                tab2[i/k] = 0f;
                for (int j = 0; j < k; j++)
                {
                    tab2[i/k] = tab2[i/k] + (float) Math.Pow(tab[i+j], 2);
                }
            }

            return tab2;
        }

       public double[] chikwadratD(int ilosc, float pOne, double[] tabValue)
       {
           Normal nom = new Normal(ilosc, tabValue);
           int k = (int)pOne;

           // tabValue = nom.normalnyStandardowyD(ilosc*k, tabValue);
           var tab = new double[ilosc * k];
           for (int i = 0; i < ilosc * k; i++)
           {
               if (i < ilosc)
               {
                   tab[i] = tabValue[i];
               }
               else
               {
                   tab[i] = 0f;
               }
           }
           tab = nom.normalnyStandardowyD(ilosc * k, tab);

           var tab2 = new Double[ilosc];

           for (int i = 0; i < ilosc; i = i + k)
           {
               tab2[i / k] = 0f;
               for (int j = 0; j < k; j++)
               {
                   tab2[i / k] = tab2[i / k] + Math.Pow(tab[i + j], 2);
               }
           }

           return tab2;
       }


    }
}
