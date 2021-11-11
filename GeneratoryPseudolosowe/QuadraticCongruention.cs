using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class QuadraticCongruention
    {
        
            public int quanity { get; set; }
            public int parameterD { get; set; }
            public int parameterA { get; set; }
            public int parameterC { get; set; }
            public int modulo { get; set; }
            public int startValue { get; set; }

            public QuadraticCongruention(int ilosc, int d, int a, int c, int mod, int StValue)
            {
                this.quanity = ilosc;
                this.parameterD = d;
                this.parameterA = a;
                this.parameterC = c;
                this.modulo = mod;
                this.startValue = StValue;
            }

            public float[] kongruencja_kwadratowa(int ilosc, int d, int a, int c, int mod, int StValue)
            {
                var tab = new int[ilosc];
                // List<Int32> list = new List<Int32>();
                tab[0] = StValue;
                for (int i = 0; i < ilosc-1; i++)
                {
                    tab[i+1] = (d * tab[i] * tab[i] + a * tab[i] + c) % mod;
                }

                var tab2 = new float[ilosc];

                for (int i = 0; i < ilosc; i++)
                {
                    tab2[i] = ((float) tab[i] / mod);
                }


            return tab2;
            }

         

    }
}
