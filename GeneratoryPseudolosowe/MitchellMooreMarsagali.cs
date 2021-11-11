using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class MitchellMooreMarsagali
    {
        public int quanity { get; set; }
        public int modulo { get; set; }
        public int[] startValue { get; set; }

        public MitchellMooreMarsagali(int ilosc, int mod, int[] StValue)
        {
            this.quanity = ilosc;
            this.modulo = mod;
            this.startValue = StValue;
        }


        public float[] metoda_mitchell_moore(int ilosc, int mod, int[] StValue)
        {
            var tab = new int[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                if (i < 55)
                {
                    tab[i] = StValue[i];
                }
                else
                {
                    tab[i] = 0;
                }
            }

            for (int i = 55; i < ilosc; i++)
            {
               // StValue[i] = (StValue[i - 55] + StValue[i - 24]) % mod;
               tab[i] = (tab[i - 55] + tab[i - 24]) % mod;
            }

            var tab2 = new float[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
             //   tab2[i] = ((float)StValue[i] / mod);
             tab2[i] = ((float) tab[i] / mod);
            }

            return tab2;
        }

        public float[] metoda_marsagali(int ilosc, int mod, int[] StValue)
        {
            var tab = new int[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                if (i < 55)
                {
                    tab[i] = StValue[i];
                }
                else
                {
                    tab[i] = 0;
                }
            }

            for (int i = 55; i < ilosc; i++)
            {
                tab[i] = (tab[i - 55] * tab[i - 24]) % mod;
                //  StValue[i] = (StValue[i - 55] * StValue[i - 24]) % mod;
            }

            var tab2 = new float[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                // tab2[i] = ((float)StValue[i] / mod);
                tab2[i] = ((float)tab[i] / mod);
            }


            return tab2;
        }



    }
}
