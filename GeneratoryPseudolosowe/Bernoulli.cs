using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class Bernoulli
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float pTwo { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public Bernoulli(int ilosc, float Pa, float Pb, float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tab = tabValue;
        }

        public Bernoulli(int ilosc, float Pa, float Pb, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tabD = tabValue;
        }


        public static long Newton(int n, int k)
        {
            long Wynik = 1;       // Deklaracja zmiennych
            int i;

            for (i = 1; i <= k; i++) // Od 1 do k wykonujemy :
            {
                Wynik = Wynik * (n - i + 1) / i;      // Obliczanie ze wzoru iteracyjnego
            }

            return Wynik;   // Zwróć Wynik
        }

        public float[] dwumianowy(int ilosc, float pOne, float pTwo, float[] tabValue)
        {
            int m = (int) pOne;
            var tabp = new float[(int)pOne+1];
            var tabd = new float[(int)pOne + 1];

            for (int k = 0; k <= pOne; k++)
            {
             
              tabp[k]= Newton(m,k) * (float)Math.Pow(pTwo, k) * (float)Math.Pow(1 - pTwo, m - k);
            }

            tabd[0] = tabp[0];
            for (int j = 1; j <= m; j++)
            {
                tabd[j] = tabd[j - 1] + tabp[j];
            }

            var tab = new float[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] < tabd[0])
                {
                    tab[i] = 0;
                }

                for (int j = 1; j <= m; j++)
                {
                    if (tabValue[i] < tabd[j] && tabValue[i] >= tabd[j - 1])
                    {
                        tab[i] = j;
                    }
                }
            }

            return tab;
        }

        public double[] dwumianowyD(int ilosc, float pOne, float pTwo, double[] tabValue)
        {
            int m = (int)pOne;
            var tabp = new double[(int)pOne + 1];
            var tabd = new double[(int)pOne + 1];

            for (int k = 0; k <= pOne; k++)
            {

                tabp[k] = Newton(m, k) * Math.Pow(pTwo, k) * Math.Pow(1 - pTwo, m - k);
            }

            tabd[0] = tabp[0];
            for (int j = 1; j <= m; j++)
            {
                tabd[j] = tabd[j - 1] + tabp[j];
            }

            var tab = new double[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] < tabd[0])
                {
                    tab[i] = 0;
                }

                for (int j = 1; j <= m; j++)
                {
                    if (tabValue[i] < tabd[j] && tabValue[i] >= tabd[j - 1])
                    {
                        tab[i] = j;
                    }
                }
            }

            return tab;
        }

    }
}

