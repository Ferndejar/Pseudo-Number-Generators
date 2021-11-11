using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class Geometric
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float pTwo { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public Geometric(int ilosc, float Pa, float Pb, float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tab = tabValue;
        }

        public Geometric(int ilosc, float Pa, float Pb, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tabD = tabValue;
        }

        public float[] geometryczny(int ilosc, float pOne, float pTwo, float[] tabValue)
        {
            int m = (int) pTwo;
            var tabp = new float[m];
            var tabd = new float[m];
            float s = 0f;
            for (int i = 0; i < m-1; i++)
            {
                tabp[i] = pOne * (float) Math.Pow(1 - pOne, i);
                s = s + tabp[i];
                tabp[m - 1] = 1 - s;
            }

            tabd[0] = tabp[0];

            for (int j = 1; j < m; j++)
            {
                tabd[j] = tabd[j - 1] + tabp[j];
            }

            var tab = new float[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] < tabd[0])
                {
                    tab[i] = 1;
                }

                for (int j = 1; j < m; j++)
                {
                    if (tabValue[i] < tabd[j] && tabValue[i] >= tabd[j - 1])
                    {
                        tab[i] = j + 1;
                    }
                }
            }

            return tab;
        }

        public double[] geometrycznyD(int ilosc, float pOne, float pTwo, double[] tabValue)
        {
            int m = (int)pTwo;
            var tabp = new double[m];
            var tabd = new double[m];
            double s = 0f;
            for (int i = 0; i < m - 1; i++)
            {
                tabp[i] = pOne * Math.Pow(1 - pOne, i);
                s = s + tabp[i];
                tabp[m - 1] = 1 - s;
            }

            tabd[0] = tabp[0];

            for (int j = 1; j < m; j++)
            {
                tabd[j] = tabd[j - 1] + tabp[j];
            }

            var tab = new double[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] < tabd[0])
                {
                    tab[i] = 1;
                }

                for (int j = 1; j < m; j++)
                {
                    if (tabValue[i] < tabd[j] && tabValue[i] >= tabd[j - 1])
                    {
                        tab[i] = j + 1;
                    }
                }
            }

            return tab;
        }

    }

}

