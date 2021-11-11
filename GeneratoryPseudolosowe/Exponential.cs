using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class Exponential
    {

        public int quanity { get; set; }
        public float lambda { get; set; }
        public float[] tab { get; set; }
        public int modulo { get; set; }
        public double[] tabD { get; set; }

        public Exponential(int ilosc, float l, int m,float[] tabValue)
        {
            this.quanity = ilosc;
            this.lambda = l;
            this.tab = tabValue;
            this.modulo = m;
        }

        public Exponential(int ilosc, float l, int m, double[] tabValue)
        {
            this.quanity = ilosc;
            this.lambda = l;
            this.tabD = tabValue;
            this.modulo = m;
        }


        public float[] wykladniczy(int ilosc, float l,int m, float[] tabValue)
        {
             double  d = (double) 1 / m;

            var tab2 = new float[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                if (Math.Abs(tabValue[i]) < 0.001)
                {
                    tab2[i] = (float)((-1 / l) * Math.Log(d));
                }
                else
                {
                    tab2[i] = (float)((-1 / l) * Math.Log(tabValue[i]));
                }
               
                
            }

            return tab2;
        }

        public double[] wykladniczyD(int ilosc, float l, int m, double[] tabValue)
        {
            double d = 1 / Math.Pow(10,m);

            var tab2 = new double[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                if (Math.Abs(tabValue[i]) < 0.001)
                {
                    tab2[i] = ((-1 / l) * Math.Log(d));
                }
                else
                {
                    tab2[i] = ((-1 / l) * Math.Log(tabValue[i]));
                }


            }

            return tab2;
        }


    }
}
