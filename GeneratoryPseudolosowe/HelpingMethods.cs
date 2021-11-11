using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class HelpingMethods
    {
        public static long Newton(int n, int k)
        {
            long Wynik = 1;      
            int i;

            for (i = 1; i <= k; i++) 
            {
                Wynik = Wynik * (n - i + 1) / i;      
            }

            return Wynik;   
        }

        public int factorial(int n)
        {
            int fact = 1;
            while (n != 1)
            {
                fact = fact * n;
                n = n - 1;
            }

            return fact;
        }
       public float[] textToFloatArray(String text)
        {

            string[] subs = text.Split(' ');
            int size = subs.Length;
            float[] tab = new float[size];
            int i = 0;
            foreach (var sub in subs)
            {
                tab[i++] = float.Parse(sub);
            }

            return tab;
        }
    }
}
