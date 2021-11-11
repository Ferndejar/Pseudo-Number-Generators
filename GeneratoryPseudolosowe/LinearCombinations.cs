using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class LinearCombinations
    {
        public int quanity { get; set; }
        public int parameterK { get; set; }
        public int[] parameterA { get; set; }
        public int modulo { get; set; }
        public int[] startValue { get; set; }

        public LinearCombinations(int ilosc, int k, int[] a, int mod, int[] StValue)
        {
            this.quanity = ilosc;
            this.parameterK = k;
            this.parameterA = a;
            this.modulo = mod;
            this.startValue = StValue;
        }

        public float[] kombinacje_liniowe(int ilosc, int k, int mod, int[] a, int[] StValue)
        {
            int[] tab_value = new  int[ilosc];
            int[] tab_pA = new int[ilosc];
            for (int i = 0; i < k; i++)
            {
                tab_value[i] = StValue[i];
                tab_pA[i] = a[i];
            }

            for (int i = k; i < ilosc; i++)
            {
                tab_value[i] = 0;
                for (int j = 0; j < k; j++)
                {
                    tab_value[i] = (tab_value[i] + tab_value[i-j-1] * tab_pA[k-1-j]) % mod;
                }
               
            }

            var tab = new float[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                tab[i] = (float) (tab_value[i]) / mod;
            }

            return tab;
        }
    }
}
