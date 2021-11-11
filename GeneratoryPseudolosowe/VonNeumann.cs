using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class VonNeumann
    {
        public int quanity { get; set; }
        public int parameter2k { get; set; }
        public int startValue { get; set; }

        public VonNeumann(int ilosc, int k, int StValue)
        {
            this.quanity = ilosc;
            this.parameter2k = k;
            this.startValue = StValue;
        }

        public double[] metoda_von_Neumann(int ilosc, int k, long StValue)
        {
            var tab = new long[ilosc];
          
            tab[0] = StValue;
            for (int i = 0; i < ilosc - 1; i++)
            {
                tab[i + 1] = (long) (((tab[i] * tab[i])/Math.Pow(10,k/2) ) % Math.Pow(10,k));
            }

            var tab2 = new double[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                tab2[i] = ((float)tab[i] / Math.Pow(10,k));

                if (tab2[i] < 0.001)
                {
                    tab2[i] = 0.001;
                }
            }


            return tab2;
        }
    }
}
