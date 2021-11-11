using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class Uniform
    {
        public int quanity { get; set; }
        public float Pa { get; set; }
        public float Pb { get; set; }
        public float[] tab { get; set; }
        public double[] tabD { get; set; }

        public Uniform(int ilosc, float a, float b, float[] tabValue)
        {
            this.quanity = ilosc;
            this.Pa = a;
            this.Pb = a;
            this.tab = tabValue;

        }

        public Uniform(int ilosc, float a, float b, double[] tabValue)
        {
            this.quanity = ilosc;
            this.Pa = a;
            this.Pb = a;
            this.tabD = tabValue;

        }

        static T Multiply<T>(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx * dy;
        }
        static T Add<T>(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx + dy;
        }


        public float[] jednostajny(int ilosc, float a, float b, float[] tabValue)
        {

            var tab2 = new float[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                tab2[i] = (b - a) * tabValue[i] + a;
            }
            return tab2;
        }

        public double[] jednostajnyD(int ilosc, float a, float b, double[] tabValue)
        {

            var tab2 = new double[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                tab2[i] = (b - a) * tabValue[i] + a;
            }
            return tab2;
        }


        /*  public static T[] jednostajny<T>(int ilosc, float a, float b, T[] tabValue)
          {
              if (typeof(T).Equals(typeof(float)))
              {

                  var tab2 = new float[ilosc];
                  for (int i = 0; i < ilosc; i++)
                  {


                      tab2[i] = Multiply((b - a), Add(tabValue[i], a));

                      // Multiply((b - a), Add(tabValue[i], a));
                      //(b - a) * tabValue[i] + a);
                  }
              }
              return tab2;
          }*/

    }
}
 