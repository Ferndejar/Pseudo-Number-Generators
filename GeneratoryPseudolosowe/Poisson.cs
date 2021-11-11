using System;

namespace GeneratoryPseudolosowe
{
    class Poisson
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float pTwo { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public Poisson(int ilosc, float Pa, float Pb, float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tab = tabValue;
        }

        public Poisson(int ilosc, float Pa, float Pb, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tabD = tabValue;
        }

        public int factorial(int n)
        {
            int fact = 1;
            while (n != 1)
            {
                fact = fact * n;
                n = n - 1;
            }

            return fact;
        }

        public float[] poissona(int ilosc, float pOne, float pTwo, float[] tabValue)
        {
            int m = (int)pTwo;
            var tabp = new float[m+1];
            var tabd = new float[m+1];
            float s = 0f;
            int fact = 1;
            for (int i = 0; i < m ; i++)
            {
                /*    for (int k = 1; k<=m; k++)
                    {
                        fact = fact * k;
                        tabp[k] = (float)(Math.Pow(pOne, i) / fact) * (float)Math.Exp(-pOne);
                    }*/
                if (i == 0)
                {
                    fact = 1;
                    tabp[i] = (float)(Math.Pow(pOne, i) / fact) * (float)Math.Exp(-pOne);
                }
                else
                {
                    fact = factorial(i);
                    tabp[i] = (float)(Math.Pow(pOne, i) / fact) * (float)Math.Exp(-pOne);
                }
                
                s = s + tabp[i];
                tabp[m] = 1 - s;
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

        public double[] poissonaD(int ilosc, float pOne, float pTwo, double[] tabValue)
        {
            int m = (int)pTwo;
            var tabp = new double[m + 1];
            var tabd = new double[m + 1];
            double s = 0f;
            int fact = 1;
            for (int i = 0; i < m; i++)
            {
                /*    for (int k = 1; k<=m; k++)
                    {
                        fact = fact * k;
                        tabp[k] = (float)(Math.Pow(pOne, i) / fact) * (float)Math.Exp(-pOne);
                    }*/
                if (i == 0)
                {
                    fact = 1;
                    tabp[i] = (Math.Pow(pOne, i) / fact) * Math.Exp(-pOne);
                }
                else
                {
                    fact = factorial(i);
                    tabp[i] = (Math.Pow(pOne, i) / fact) * Math.Exp(-pOne);
                }

                s = s + tabp[i];
                tabp[m] = 1 - s;
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
