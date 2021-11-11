using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class LinearCongruention
    {
        public int quanity { get; set; }
        public int parameterA { get; set; }
        public int parameterC { get; set; }
        public int modulo { get; set; }
        public int startValue { get; set; }

        public LinearCongruention(int ilosc, int a, int c, int mod, int StValue)
        {
            this.quanity = ilosc;
            this.parameterA = a;
            this.parameterC = c;
            this.modulo = mod;
            this.startValue = StValue;
        }

        public int[] kongruencja_liniowa(int ilosc, int a, int c, int mod, int StValue)
        {
            var tab = new int[ilosc];
           // List<Int32> list = new List<Int32>();
            tab[0] = StValue;
            int i;
            for (i = 1; i < ilosc; i++)
            {
                tab[i] = (a * tab[i - 1] + c) % mod;
            }

            return tab;
        }

    }
}
