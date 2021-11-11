using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class TStudent
    {
        public int quanity { get; set; }
        public float pOne { get; set; }
        public float pTwo { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }


        public TStudent(int ilosc, float Pa,  float[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
           // this.pTwo = Pb;
            this.tab = tabValue;

        }

        public TStudent(int ilosc, float Pa, double[] tabValue)
        {
            this.quanity = ilosc;
            this.pOne = Pa;
            // this.pTwo = Pb;
            this.tabD = tabValue;
        }



        public float[] tstudent(int ilosc, float pOne, float[] tabValue)
        {
            Normal nom = new Normal(ilosc, tabValue);
            int k = (int)pOne;
            float L=0;
            float M=0;
            //int m = (int) pTwo;
            var tabn = new float[ilosc * (k+1)];
            var tabt = new float[ilosc];

            for (int i = 0; i < ilosc * k; i++)
            {
                if (i < ilosc)
                {
                    tabn[i] = tabValue[i];
                }
                else
                {
                    tabn[i] = 0f;
                }
            }

            tabn = nom.normalnyStandardowy(ilosc*(k + 1), tabn);

            for (int i = 0; i < ilosc * (k + 1); i++)
            {
                if (i % (k + 1) == 0)
                {
                    L = tabn[i];
                    M = 0;
                }
                else if (i % (k + 1) == k)
                {
                    M = M + (float) Math.Pow(tabn[i], 2);
                    M = (float) Math.Sqrt(M);
                    tabt[(i - k) / (k + 1)] = L / M * (float) Math.Sqrt(k);
                }
                else
                {
                    M = M + (float) Math.Pow(tabn[i], 2);
                }
            }


            return tabt;
        }


        public double[] tstudentD(int ilosc, float pOne, double[] tabValue)
        {
            Normal nom = new Normal(ilosc, tabValue);
            int k = (int)pOne;
            double L = 0;
            double M = 0;
            //int m = (int) pTwo;
            var tabn = new double[ilosc * (k + 1)];
            var tabt = new double[ilosc];

            for (int i = 0; i < ilosc * k; i++)
            {
                if (i < ilosc)
                {
                    tabn[i] = tabValue[i];
                }
                else
                {
                    tabn[i] = 0f;
                }
            }

            tabn = nom.normalnyStandardowyD(ilosc * (k + 1), tabn);

            for (int i = 0; i < ilosc * (k + 1); i++)
            {
                if (i % (k + 1) == 0)
                {
                    L = tabn[i];
                    M = 0;
                }
                else if (i % (k + 1) == k)
                {
                    M = M + Math.Pow(tabn[i], 2);
                    M = Math.Sqrt(M);
                    tabt[(i - k) / (k + 1)] = L / M * Math.Sqrt(k);
                }
                else
                {
                    M = M + Math.Pow(tabn[i], 2);
                }
            }


            return tabt;
        }
    }
}
