using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratoryPseudolosowe
{
    public partial class Form3 : Form
    {
        private int size;
        private int pk;
        private int sT;
   
        private float pamOne;
        private float pamTwo;
        private float lvlofDeg;
        private float[] edgeClasses;

        public Form3()
        {
            InitializeComponent();
            textBox1.Text = "50";
            textBox2.Text = "6";
            textBox3.Text = "243783";
            comboBox1.Text = "0,1";
            pamOne_tb.Text = "0";
            pamTwo_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = false;
            pamTwo_tb.Enabled = false;
        }

        float[] textToFloatArray(String text)
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

        float[] toFloatArray(double[] arr)
        {
            if (arr == null) return null;
            int n = arr.Length;
            float[] ret = new float[n];
            for (int i = 0; i < n; i++)
            {
                ret[i] = (float)arr[i];
            }
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && class_tb.Text != "" && pamOne_tb.Text != "" && pamTwo_tb.Text != "")
            {
                size = int.Parse(textBox1.Text);
                pk = int.Parse(textBox2.Text);
                sT = int.Parse(textBox3.Text);
                StringBuilder sb = new StringBuilder();
                if (size > 1 && pk % 2 == 0 && sT > 0)
                {
                    VonNeumann vN = new VonNeumann(size, pk, sT);
                    double[] tab = new double[size];
                    tab = vN.metoda_von_Neumann(size, pk, sT);

                    if (Exp_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        if (pamOne > 0)
                        {
                          
                            Exponential exp = new Exponential(size, pamOne, pk, tab);
                            double[] tabDouble = exp.wykladniczyD(size, pamOne, pk, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {

                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);
                                bool isGoodEdgeClasses = true;

                                for (int i = 0; i < edgeClasses.Length; i++)
                                {
                                    if (edgeClasses[i] < 0)
                                    {
                                        richTextBox1.Text =
                                            "\nBrzegi klas powinny byc z przedzialu [0,∞]";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }

                                }

                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed = pear.licznoscTeoretycznaExp(size, edgeClasses.Length,
                                        edgeClasses, pamOne);
                                    float stat = pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed,
                                        tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);


                                    resultOfTest(stat, quantile, "wykladniczego");
                                }
                            }

                            else if (Kol_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tabDouble));
                                float stat = kol.statystykaKolmogorowa(size, toFloatArray(tabDouble), pamOne, 0, "Exp");
                                float quantile = kol.TQuantile(size, lvlofDeg);

                                resultOfTestKol(stat, quantile, "wykladniczego");

                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "\nParametr lambda rozkladu wykladniczego musi byc dodatni";
                        }
                    }

                    else if (Uni_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        pamTwo = float.Parse(pamTwo_tb.Text);
                        if (pamTwo > pamOne)
                        {
                            Uniform unf = new Uniform(size, pamOne, pamTwo, tab);
                            double[] tabDouble = unf.jednostajnyD(size, pamOne, pamTwo, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);
                                bool isGoodEdgeClasses = true;
                                for (int i = 0; i < edgeClasses.Length; i++)
                                {
                                    if (edgeClasses[i] > 1 || edgeClasses[i] < 0)
                                    {
                                        richTextBox1.Text =
                                            "\nBrzegi klas powinny byc z przedzialu [" + pamOne + "," + pamTwo + "]";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }

                                }

                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed = pear.licznoscTeoretycznaJed(size, edgeClasses.Length,
                                        edgeClasses, pamOne, pamTwo);
                                    float stat = pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed,
                                        tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                    resultOfTest(stat, quantile, "jednostajnego");
                                }

                            }
                            else if (Kol_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tabDouble));
                                float stat = kol.statystykaKolmogorowa(size, toFloatArray(tabDouble), pamOne, pamTwo, "J");
                                float quantile = kol.TQuantile(size, lvlofDeg);

                                resultOfTestKol(stat, quantile, "jednostajnego");

                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Koniec przedzialu powiniec byc wiekszy od jego poczatku, podaj jeszcze raz";
                        }
                    }

                    else if (Norm_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        pamTwo = float.Parse(pamTwo_tb.Text);
                        if (pamTwo > 0)
                        {
                            if (size % 2 == 0)
                            {
                                Normal nom = new Normal(size, pamOne, pamTwo, tab);
                                double[] tabDouble = nom.normalnyD(size, pamOne, pamTwo, tab);
                                printTextToRichtextBox(size, tabDouble);
                                if (ChiTestQ_rb.Checked)
                                {
                                    string value = this.comboBox1.SelectedItem.ToString();
                                    lvlofDeg = float.Parse(value);
                                    edgeClasses = textToFloatArray(class_tb.Text);
                                    Array.Sort(edgeClasses);
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed = pear.licznoscTeoretycznaNom(size, edgeClasses.Length, edgeClasses,
                                        pamOne, pamTwo);
                                    float stat = pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);


                                    resultOfTest(stat, quantile, "normalnego");

                                }
                                else if (Kol_rb.Checked)
                                {
                                    string value = this.comboBox1.SelectedItem.ToString();
                                    lvlofDeg = float.Parse(value);
                                    KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tabDouble));
                                    float stat =
                                        kol.statystykaKolmogorowa(size, toFloatArray(tabDouble), pamOne, pamTwo, "Nom");
                                    float quantile = kol.TQuantile(size, lvlofDeg);

                                    resultOfTestKol(stat, quantile, "normalnego");

                                }
                            }
                            else
                            {
                                richTextBox1.Text = "\nWprowadzona ilosc danych do wygenerowania powinna byc parzysta podaj jeszcze raz";
                            }
                        }
                        else
                        {

                            richTextBox1.Text =
                                "Parametr sigma musi byc wiekszy od 0";
                        }
                      

                    }


                    else if (NormSt_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        pamTwo = float.Parse(pamTwo_tb.Text);
                        if (size % 2 == 0)
                        {
                            Normal nom = new Normal(size, tab);
                            double[] tabDouble = nom.normalnyStandardowyD(size, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);
                                PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                    toFloatArray(tabDouble));
                                int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                    edgeClasses);
                                float[] tabPearJed = pear.licznoscTeoretycznaNomSt(size, edgeClasses.Length, edgeClasses);
                                float stat = pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);


                                resultOfTest(stat, quantile, "normalnego standardowego");

                            }
                            else if (Kol_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tabDouble));
                                float stat =
                                    kol.statystykaKolmogorowa(size, toFloatArray(tabDouble), pamOne, pamTwo, "NomS");
                                float quantile = kol.TQuantile(size, lvlofDeg);

                                resultOfTestKol(stat, quantile, "normalnego standardowego");

                            }
                        }
                        else
                        {
                            richTextBox1.Text = "\nWprowadzona ilosc danych do wygenerowania powinna byc parzysta podaj jeszcze raz";
                        }
                    }
                    else if (ChiQ_rb.Checked)
                    {

                        pamOne = float.Parse(pamOne_tb.Text);
                        if (pamOne >= 1)
                        {
                            if (size % 2 == 0 || pamOne % 2 == 0)
                            {
                                int newsize = (int)pamOne * size;
                                tab = vN.metoda_von_Neumann(newsize, pk, sT);
                                double[] tabf2 = new double[newsize];

                                for (int i = 0; i < newsize; i++)
                                {
                                    tabf2[i] = tab[i];
                                }


                                ChiQuadrat chq = new ChiQuadrat(newsize, pamOne, tabf2);
                                double[] tabDouble = chq.chikwadratD(newsize, pamOne, tabf2);

                                printTextToChiRichtextBox(newsize, tabDouble);
                                if (ChiTestQ_rb.Checked)
                                {


                                    string value = this.comboBox1.SelectedItem.ToString();
                                    lvlofDeg = float.Parse(value);
                                    edgeClasses = textToFloatArray(class_tb.Text);
                                    Array.Sort(edgeClasses);

                                    bool isGoodEdgeClasses = true;

                                    for (int i = 0; i < edgeClasses.Length; i++)
                                    {
                                        if (edgeClasses[i] < 0)
                                        {
                                            richTextBox1.Text =
                                                "\nBrzegi klas powinny byc z przedzialu [0,∞]";
                                            isGoodEdgeClasses = false;
                                            break;

                                        }

                                    }

                                    if (isGoodEdgeClasses)
                                    {
                                        PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length, toFloatArray(tabDouble));
                                        int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length, edgeClasses);
                                        float[] tabPearJed =
                                            pear.licznoscTeoretycznaChiQ(size, edgeClasses.Length, edgeClasses, pamOne);
                                        float stat = pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                        float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                        resultOfTest(stat, quantile, "chi kwadrat");
                                    }
                                }
                                else if (Kol_rb.Checked)
                                {
                                    string value = this.comboBox1.SelectedItem.ToString();
                                    lvlofDeg = float.Parse(value);
                                    KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tabDouble));
                                    float stat = kol.statystykaKolmogorowa(size, toFloatArray(tabDouble), pamOne, 0, "Chi");
                                    float quantile = kol.TQuantile(size, lvlofDeg);

                                    resultOfTestKol(stat, quantile, "chi kwadrat");

                                }
                            }
                            else
                            {
                                richTextBox1.Text = "Przynajmniej jedna z wartości z pól ilość lub parametr 1 (stopnie swobody) powinna byc parzysta";
                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Stopien swobody musi byc wiekszy rowny 1";
                        }

                       
                    }

                    else if (ZeroOne_rb.Checked)
                    {

                        pamOne = float.Parse(pamOne_tb.Text);
                        if (pamOne > 0 && pamOne < 1)
                        {
                            ZeroOne zro = new ZeroOne(size, pamOne, tab);
                            double[] tabDouble = zro.zerojedynkowyD(size, pamOne, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {

                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);

                                bool isGoodEdgeClasses = true;

                                for (int i = 1; i <= edgeClasses.Length - 1; i++)
                                {
                                    if ((int)edgeClasses[i] - (int)edgeClasses[i - 1] < 1)
                                    {
                                        richTextBox1.Text =
                                            "Podane brzegi definiuja puste klasy podaj jeszcze raz.";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed =
                                        pear.licznoscTeoretycznaZeroOne(size, edgeClasses.Length, edgeClasses,
                                            pamOne);
                                    float stat =
                                        pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                    resultOfTest(stat, quantile, "zerojedynkowego");
                                }
                            }
                        }
                        else
                        {
                            richTextBox1.Text = "Parametr 1 powinien znajdowac sie w przedziale (0,1)";
                        }
                    }
                    else if (Bern_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        pamTwo = float.Parse(pamTwo_tb.Text);
                        if (pamOne > 0 && pamTwo > 0 && pamTwo < 1)
                        {
                            Bernoulli ber = new Bernoulli(size, pamOne, pamTwo, tab);
                            double[] tabDouble = ber.dwumianowyD(size, pamOne, pamTwo, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);
                                bool isGoodEdgeClasses = true;

                                for (int i = 0; i < edgeClasses.Length; i++)
                                {
                                    if (edgeClasses[i] > pamOne || edgeClasses[i] < 0)
                                    {
                                        richTextBox1.Text =
                                            "\nBrzegi klas powinny byc z przedzialu [" + 0 + "," + pamOne + "]";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                for (int i = 1; i <= edgeClasses.Length - 1; i++)
                                {
                                    if ((int)edgeClasses[i] - (int)edgeClasses[i - 1] < 1)
                                    {
                                        richTextBox1.Text =
                                            "Podane brzegi definiuja puste klasy podaj jeszcze raz.";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed = pear.licznoscTeoretycznaBernoulli(size, edgeClasses.Length,
                                        edgeClasses, pamOne, pamTwo);
                                    float stat =
                                        pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                    resultOfTest(stat, quantile, "Bernoulliego");
                                }
                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Parametr1 musi byc wiekszy 0 a parametr2 miescic sie w przedziale (0,1)";
                        }
                    }
                    else if (UniDis_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        if (pamOne > 0)
                        {
                            DiscreteUniform dtu = new DiscreteUniform(size, pamOne, tab);
                            double[] tabDouble = dtu.jednostajnyDyskretnyD(size, pamOne, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);

                                bool isGoodEdgeClasses = true;

                                for (int i = 0; i < edgeClasses.Length; i++)
                                {
                                    if (edgeClasses[i] > pamOne || edgeClasses[i] < 1)
                                    {
                                        richTextBox1.Text =
                                            "\nBrzegi klas powinny byc z przedzialu [" + 1 + "," + pamOne + "]";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                for (int i = 1; i <= edgeClasses.Length - 1; i++)
                                {
                                    if ((int)edgeClasses[i] - (int)edgeClasses[i - 1] < 1)
                                    {
                                        richTextBox1.Text =
                                            "Podane brzegi definiuja puste klasy podaj jeszcze raz.";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed =
                                        pear.licznoscTeoretycznaJedDys(size, edgeClasses.Length, edgeClasses,
                                            pamOne);
                                    float stat =
                                        pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                    resultOfTest(stat, quantile, "jednostajnego dyskretnego");
                                }
                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Parametr 1 powinien byc dodatni";
                        }
                    }
                    else if (Geo_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        pamTwo = float.Parse(pamTwo_tb.Text);
                        if (pamOne > 0 && pamOne < 1 && pamTwo > 0)
                        {
                            Geometric geo = new Geometric(size, pamOne, pamTwo, tab);
                            double[] tabDouble = geo.geometrycznyD(size, pamOne, pamTwo, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {

                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);

                                bool isGoodEdgeClasses = true;

                                for (int i = 0; i < edgeClasses.Length; i++)
                                {
                                    if (edgeClasses[i] > pamTwo || edgeClasses[i] < 1)
                                    {
                                        richTextBox1.Text =
                                            "\nBrzegi klas powinny byc z przedzialu [" + 1 + "," + pamTwo + "]";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                for (int i = 1; i <= edgeClasses.Length - 1; i++)
                                {
                                    if ((int)edgeClasses[i] - (int)edgeClasses[i - 1] < 1)
                                    {
                                        richTextBox1.Text =
                                            "Podane brzegi definiuja puste klasy podaj jeszcze raz.";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed = pear.licznoscTeoretycznaGeo(size, edgeClasses.Length,
                                        edgeClasses,
                                        pamOne, pamTwo);
                                    float stat =
                                        pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                    resultOfTest(stat, quantile, "geometrycznego");
                                }
                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Parametr 1 powinien znajdowaj sie w przedziale (0,1) a parametr 2 powininen byc wiekszy od 0";
                        }
                    }
                    else if (Poi_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        pamTwo = float.Parse(pamTwo_tb.Text);
                        if (pamOne > 0 && pamTwo > 0 && pamOne < 1)
                        {
                            Poisson poi = new Poisson(size, pamOne, pamTwo, tab);
                            double[] tabDouble = poi.poissonaD(size, pamOne, pamTwo, tab);
                            printTextToRichtextBox(size, tabDouble);
                            if (ChiTestQ_rb.Checked)
                            {

                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                Array.Sort(edgeClasses);
                                bool isGoodEdgeClasses = true;

                                for (int i = 0; i < edgeClasses.Length; i++)
                                {
                                    if (edgeClasses[i] > pamTwo || edgeClasses[i] < 0)
                                    {
                                        richTextBox1.Text =
                                            "\nBrzegi klas powinny byc z przedzialu [" + 0 + "," + pamTwo + "]";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }

                                for (int i = 1; i <= edgeClasses.Length - 1; i++)
                                {
                                    if ((int)edgeClasses[i] - (int)edgeClasses[i - 1] < 1)
                                    {
                                        richTextBox1.Text =
                                            "Podane brzegi definiuja puste klasy podaj jeszcze raz.";
                                        isGoodEdgeClasses = false;
                                        break;
                                    }
                                }
                                if (isGoodEdgeClasses)
                                {
                                    PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length,
                                        toFloatArray(tabDouble));
                                    int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length,
                                        edgeClasses);
                                    float[] tabPearJed = pear.licznoscTeoretycznaPoisson(size, edgeClasses.Length,
                                        edgeClasses,
                                        pamOne, pamTwo);
                                    float stat =
                                        pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                    float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                    resultOfTest(stat, quantile, "Poissona");
                                }
                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Parametr 1 powinien znajdowaj sie w przedziale (0,1) a parametr 2 powininen byc wiekszy od 0";
                        }
                    }
                    else if (TStudent_rb.Checked)
                    {
                        pamOne = float.Parse(pamOne_tb.Text);
                        if (pamOne >= 1)
                        {
                            int newsize = (int)(pamOne + 1) * size;
                            tab = vN.metoda_von_Neumann(newsize, pk, sT);
                            double[] tabf2 = new double[newsize];

                            for (int i = 0; i < newsize; i++)
                            {
                                tabf2[i] = tab[i];
                            }
                            TStudent tst = new TStudent(newsize, pamOne, tabf2);
                            double[] tabDouble = tst.tstudentD(newsize, pamOne, tabf2);

                            printTextToTsTRichtextBox(newsize, tabDouble);

                            if (ChiTestQ_rb.Checked)
                            {

                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                edgeClasses = textToFloatArray(class_tb.Text);
                                PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length, toFloatArray(tabDouble));
                                int[] tabCount = pear.licznoscKlas(size, toFloatArray(tabDouble), edgeClasses.Length, edgeClasses);
                                float[] tabPearJed = pear.licznoscTeoretycznaTStudent(size, edgeClasses.Length, edgeClasses, pamOne);
                                float stat = pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);


                                resultOfTest(stat, quantile, "T-Studenta");

                            }
                            else if (Kol_rb.Checked)
                            {
                                string value = this.comboBox1.SelectedItem.ToString();
                                lvlofDeg = float.Parse(value);
                                KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tabDouble));
                                float stat = kol.statystykaKolmogorowa(size, toFloatArray(tabDouble), pamOne, 0, "Tstudent");
                                float quantile = kol.TQuantile(size, lvlofDeg);

                                resultOfTestKol(stat, quantile, "T-Studenta");

                            }
                        }
                        else
                        {
                            richTextBox1.Text =
                                "Stopien swobody musi byc wiekszy rowny 1";
                        }

                       
                    }



                    else if (UniSt_rb.Checked)
                    {
                        printTextToRichtextBox(size, tab);
                        if (ChiTestQ_rb.Checked)
                        {

                          string value = this.comboBox1.SelectedItem.ToString();
                                    lvlofDeg = float.Parse(value);
                                    edgeClasses = textToFloatArray(class_tb.Text);
                                    Array.Sort(edgeClasses);
                                    bool isGoodEdgeClasses = true;

                                    for (int i = 0; i < edgeClasses.Length; i++)
                                    {
                                        if (edgeClasses[i] > 1 || edgeClasses[i] < 0)
                                        {
                                            richTextBox1.Text = "\nLiczby powinny byc z przedzialu [0,1]";
                                            isGoodEdgeClasses = false;
                                            break;
                                        }
                                    }

                                    if (isGoodEdgeClasses)
                                    {
                                        PearsonTest pear = new PearsonTest(size, edgeClasses, edgeClasses.Length, toFloatArray(tab));
                                        int[] tabCount = pear.licznoscKlas(size, toFloatArray(tab), edgeClasses.Length, edgeClasses);
                                        float[] tabPearJed =
                                            pear.licznoscTeoretycznaJedStan(size, edgeClasses.Length, edgeClasses);
                                        float stat =
                                            pear.statystykaTestowaPearson(edgeClasses.Length, tabPearJed, tabCount);
                                        float quantile = pear.Kwantyl(edgeClasses.Length, lvlofDeg);
                                        resultOfTest(stat, quantile, "jednostajnego standardowego");
                                    }
                        }
                        else if (Kol_rb.Checked)
                        {
                            string value = this.comboBox1.SelectedItem.ToString();
                            lvlofDeg = float.Parse(value);
                            KolmogorovTest kol = new KolmogorovTest(size, toFloatArray(tab));
                            float stat = kol.statystykaKolmogorowa(size, toFloatArray(tab), 0, 1, "JS");
                            float quantile = kol.TQuantile(size, lvlofDeg);

                            resultOfTestKol(stat, quantile, "jednostajnego standardowego");

                        }
                    }
                }
                else
                {
                    richTextBox1.Text = "Podane parametry sa nie prawidlowe, prosze podac jeszcze raz";
                }
            }
            else
            {
                richTextBox1.Text = "Wartosci pol parametrow nie moga byc puste";
            }
          
          

        }

        private void printTextToChiRichtextBox(int size, double[] tab)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = (float)Math.Round(tab[i] * Math.Pow(10f, pk)) / Math.Pow(10f, pk);

                if (tab[i] != 0)
                {
                    sb.AppendFormat("{0}", tab[i]);
                    sb.AppendLine();
                }
            }

            richTextBox1.Text = sb.ToString();
        }

        private void printTextToTsTRichtextBox(int size, double[] tab)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = Math.Round(tab[i] * Math.Pow(10f, pk)) / Math.Pow(10f, pk);
                if (!Single.IsNaN((float)tab[i]))
                {
                    sb.AppendFormat("{0}", tab[i]);
                    sb.AppendLine();
                }
            }

            richTextBox1.Text = sb.ToString();
        }




        private void printTextToRichtextBox(int size, double[] tab)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = Math.Round(tab[i] * Math.Pow(10f,pk)) / Math.Pow(10f, pk);
            sb.AppendFormat("{0}", tab[i]);
                sb.AppendLine();
            }

            richTextBox1.Text = sb.ToString();
        }

        private void Uni_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0";
            pamTwo_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = true;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void UniSt_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0";
            pamTwo_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = false;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void Exp_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void ChiQ_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "5";
            pamTwo_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void Norm_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0";
            pamTwo_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = true;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void NormSt_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0";
            pamTwo_tb.Text = "1";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = false;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void TStudent_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "6";
            class_tb.Text = "0,3 0,6";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void Bern_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "6";
            pamTwo_tb.Text = "0,4";
            class_tb.Text = "1 2";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = true;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void Poi_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0,4";
            pamTwo_tb.Text = "6";
            class_tb.Text = "1 2";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = true;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void Geo_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0,4";
            pamTwo_tb.Text = "6";
            class_tb.Text = "1 2";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = true;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void ZeroOne_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "0,4";
            pamTwo_tb.Text = "0";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Text = "0,5";
                class_tb.Enabled = false;
            }
        }

        private void UniDis_rb_Click(object sender, EventArgs e)
        {
            pamOne_tb.Text = "6";
            class_tb.Text = "1 2";
            pamOne_tb.Enabled = true;
            pamTwo_tb.Enabled = false;
            if (ChiTestQ_rb.Checked)
            {
                class_tb.Enabled = true;
            }
            else
            {
                class_tb.Enabled = false;
            }
        }

        private void resultOfTest(float statTest, float quantile, string text)
        {
            size = int.Parse(textBox1.Text);
            string value = this.comboBox1.SelectedItem.ToString();
            lvlofDeg = float.Parse(value);
            edgeClasses = textToFloatArray(class_tb.Text);
            richTextBox1.Text += "\nWartosc statystyki testowej Chi-kwadrat Pearsona wynosi " + statTest;
            richTextBox1.Text += "\nKwantyl rozkladu Chi-kwadrat o " + edgeClasses.Length + " stopniach swobody na " +
                                 "poziomie istotnosci "
                                 + lvlofDeg + " wynosi: " + quantile + " w zwiazku z czym zbior krytyczny ma postac ("
                                 + quantile + ",∞)";
            if (statTest >= quantile)
            {
                richTextBox1.Text += "\nNa podstawie testu Chi-kwadrat Pearsona na poziomie istotnosci "
                                     + lvlofDeg + " stwierdzamy ze statystyka testowa wpada do zbioru krytycznego,"
                                     + " wiec odrzucamy hipoteze, ze wygenerowany ciag wartosci pochodzi z rozkladu " + text
                                     + "\nCiag nie moze zostac uznany za pseudolosowy wzgledem rozkladu " + text;
            }
            else
            {
                richTextBox1.Text += "\nNa podstawie testu Chi-kwadrat Pearsona na poziomie istotnosci "
                                     + lvlofDeg + " stwierdzamy ze statystyka testowa nie wpada do zbioru krytycznego,"
                                     + " wiec przyjmujemy hipoteze, ze wygenerowany ciag wartosci pochodzi z rozkladu " + text
                                     + "\nCiag moze zostac uznany za pseudolosowy wzgledem rozkladu " + text;
            }
        }

        private void resultOfTestKol(float statTest, float quantile, string text)
        {
            size = int.Parse(textBox1.Text);
            string value = this.comboBox1.SelectedItem.ToString();
            lvlofDeg = float.Parse(value);
            richTextBox1.Text += "\nWartosc statystyki testowej Kolmogorowa wynosi " + statTest;
            richTextBox1.Text += "\nKwantyl rozkladu Kolmogorowa dla proby licznosci " + size + " na poziomie istotnosci "
                                 + lvlofDeg + " wynosi: " + quantile + " w zwiazku z czym zbior krytyczny ma postac ("
                                 + quantile + ",∞)";
            if (statTest > quantile)
            {
                richTextBox1.Text += "\nNa podstawie testu Kolmogorowa dla proby licznosci " + size + " na poziomie istotnosci "
                                     + lvlofDeg + " stwierdzamy ze statystyka testowa wpada do zbioru krytycznego,"
                                     + " wiec, odrzucamy hipoteze, ze wygenerowany ciag wartosci pochodzi z rozkladu " + text
                                     + "\nCiag nie moze zostac uznany za pseudolosowy wzgledem rozkladu " + text;
            }
            else
            {
                richTextBox1.Text += "\nNa podstawie testu Kolmogorowa dla proby licznosci " + size + " na poziomie istotnosci "
                                     + lvlofDeg + " stwierdzamy ze statystyka testowa nie wpada do zbioru krytycznego"
                                     + " wiec, przyjmujemy hipoteze, ze wygenerowany ciag wartosci pochodzi z rozkladu " + text
                                     + "\nCiag moze zostac uznany za pseudolosowy wzgledem rozkladu " + text;
            }
        }

        private void ChiTestQ_rb_Click(object sender, EventArgs e)
        {
            Bern_rb.Enabled = true;
            Poi_rb.Enabled = true;
            UniDis_rb.Enabled = true;
            ZeroOne_rb.Enabled = true;
            Geo_rb.Enabled = true;
            class_tb.Enabled = true;
            if (ZeroOne_rb.Checked)
            {
                class_tb.Text = "0,5";
                class_tb.Enabled = false;
            }
        }

        private void Kol_rb_Click(object sender, EventArgs e)
        {
            Bern_rb.Enabled = false;
            Poi_rb.Enabled = false;
            UniDis_rb.Enabled = false;
            ZeroOne_rb.Enabled = false;
            Geo_rb.Enabled = false;
            class_tb.Enabled = false;
            if (ZeroOne_rb.Checked || Poi_rb.Checked || UniDis_rb.Checked || Bern_rb.Checked || Geo_rb.Checked)
            {
                UniSt_rb.Checked = true;
                ZeroOne_rb.Checked = false;
                Poi_rb.Checked = false;
                UniDis_rb.Checked = false;
                Bern_rb.Checked = false;
                Geo_rb.Checked = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pamOne_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void class_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }
    }
}
