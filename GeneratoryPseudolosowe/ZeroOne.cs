using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class ZeroOne
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public ZeroOne(int ilosc, float Pa, float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.tab = tabValue;
        }

        public ZeroOne(int ilosc, float Pa, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.tabD = tabValue;
        }


        public float[] zerojedynkowy(int ilosc, float pOne, float[] tabValue)
        {
            var tab = new float[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] < 1 - pOne)
                {
                    tab[i] = 0;
                }
                else
                {
                    tab[i] = 1;
                }
            }

            return tab;
        }

        public double[] zerojedynkowyD(int ilosc, float pOne, double[] tabValue)
        {
            var tab = new double[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                if (tabValue[i] < 1 - pOne)
                {
                    tab[i] = 0;
                }
                else
                {
                    tab[i] = 1;
                }
            }

            return tab;
        }


    }
}
