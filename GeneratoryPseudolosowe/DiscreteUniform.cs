using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratoryPseudolosowe
{
    class DiscreteUniform
    {
        public int quanity { get; set; }
            public float pOne { get; set; }
            public float[] tab { get; set; }
            public double[] tabD { get; set; }

            public DiscreteUniform(int ilosc, float Pa,  float[] tabValue)
            {
                this.quanity = ilosc;
                this.pOne = Pa;
                this.tab = tabValue;
            }

            public DiscreteUniform(int ilosc, float Pa, double[] tabValue)
            {
                this.quanity = ilosc;
                this.pOne = Pa;
                this.tabD = tabValue;
            }

        public float[] jednostajnyDyskretny(int ilosc, float pOne, float[] tabValue)
            {
                int m = (int)pOne;
                var tabp = new float[(int)pOne];
                var tabd = new float[(int)pOne];

                for (int k = 0; k < pOne; k++)
                {
                    tabp[k] = 1f / m;
                }

                tabd[0] = tabp[0];

                for (int j = 1; j < m; j++)
                {
                    tabd[j] = tabd[j - 1] + tabp[j];
                }

                var tab = new float[ilosc];

                for (int i = 0; i < ilosc; i++)
                {
                    if (tabValue[i] < tabd[0])
                    {
                        tab[i] = 1;
                    }

                    for (int j = 1; j < m; j++)
                    {
                        if (tabValue[i] < tabd[j] && tabValue[i] >= tabd[j - 1])
                        {
                            tab[i] = j+1;
                        }
                    }
                }

                return tab;
            }

            public double[] jednostajnyDyskretnyD(int ilosc, float pOne, double[] tabValue)
            {
                int m = (int)pOne;
                var tabp = new double[(int)pOne];
                var tabd = new double[(int)pOne];

                for (int k = 0; k < pOne; k++)
                {
                    tabp[k] = 1f / m;
                }

                tabd[0] = tabp[0];

                for (int j = 1; j < m; j++)
                {
                    tabd[j] = tabd[j - 1] + tabp[j];
                }

                var tab = new double[ilosc];

                for (int i = 0; i < ilosc; i++)
                {
                    if (tabValue[i] < tabd[0])
                    {
                        tab[i] = 1;
                    }

                    for (int j = 1; j < m; j++)
                    {
                        if (tabValue[i] < tabd[j] && tabValue[i] >= tabd[j - 1])
                        {
                            tab[i] = j + 1;
                        }
                    }
                }

                return tab;
            }

    }

    }
