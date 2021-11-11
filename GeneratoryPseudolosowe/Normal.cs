using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class Normal
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float pTwo { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public Normal(int ilosc, float[] tabValue)
        {
            this.quanity = ilosc;
            this.tab = tabValue;
        }

        public Normal(int ilosc, double[] tabValue)
        {
            this.quanity = ilosc;
            this.tabD = tabValue;
        }


        public Normal(int ilosc, float Pa, float Pb, float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tab = tabValue;
        }

        public Normal(int ilosc, float Pa, float Pb, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            this.pTwo = Pb;
            this.tabD = tabValue;
        }


        public float[] normalnyStandardowy(int ilosc, float[] tabValue)
        {
            var tab2 = new float[ilosc];
            for (int i = 0; i < ilosc; i += 2)
            {
                tab2[i] = (float) Math.Sqrt(-2 * Math.Log(tabValue[i])) *
                          (float) Math.Cos(2 * Math.PI * tabValue[i + 1]);
                tab2[i + 1] = (float) Math.Sqrt(-2 * Math.Log(tabValue[i])) *
                              (float) Math.Sin(2 * Math.PI * tabValue[i + 1]);
            }

            return tab2;
        }

        public double[] normalnyStandardowyD(int ilosc, double[] tabValue)
        {
            var tab2 = new double[ilosc];
            for (int i = 0; i < ilosc; i += 2)
            {
                tab2[i] = Math.Sqrt(-2 * Math.Log(tabValue[i])) * Math.Cos(2 * Math.PI * tabValue[i + 1]);
                tab2[i + 1] = Math.Sqrt(-2 * Math.Log(tabValue[i])) * Math.Sin(2 * Math.PI * tabValue[i + 1]);
            }

            return tab2;
        }


        public float[] normalny(int ilosc, float pOne, float pTwo, float[] tabValue)
        {
            var tab2 = new float[ilosc];
            tab2 = normalnyStandardowy(ilosc, tabValue);
            for (int i = 0; i < ilosc; i++)
            {
                tab2[i] = pOne + tab2[i] * pTwo;
            }

            return tab2;
        }

        public double[] normalnyD(int ilosc, float pOne, float pTwo, double[] tabValue)
        {
            var tab2 = new double[ilosc];
            tab2 = normalnyStandardowyD(ilosc, tabValue);
            for (int i = 0; i < ilosc; i++)
            {
                tab2[i] = pOne + tab2[i] * pTwo;
            }

            return tab2;
        }
    }
}