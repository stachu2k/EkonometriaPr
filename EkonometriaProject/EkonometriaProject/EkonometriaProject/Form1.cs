using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics;


namespace EkonometriaProject
{
    public partial class Form1 : Form
    {
        public List<List<double>> daneStat = new List<List<double>>();
        
        public List<double> srednie = new List<double>();
        public List<double> r0 = new List<double>();
        public List<List<double>> graf = new List<List<double>>();
        public List<double> ile_powiazan = new List<double>();
        public List<int> zwyciezcy = new List<int>();
        public double[,] r, r_pi,X;
        public double[] Y;


        public Form1()
        {
            InitializeComponent();
        }

        private void zaladujPlikMenuItem_Click(object sender, EventArgs e)
        {
            if (zaladujPlikFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataGridDane.Columns.Clear();

                    string[] textData = System.IO.File.ReadAllLines(zaladujPlikFileDialog.FileName, Encoding.UTF8);
                    string[] headers = textData[0].Split();

                    DataTable dataTable1 = new DataTable();
                    foreach (string header in headers)
                    {
                        dataTable1.Columns.Add(header, typeof(string), null);
                        daneStat.Add(new List<double>());
                    }


                    var Y = new DenseVector(textData.Length-1);

                    for (int i = 1; i < textData.Length; i++)
                    {
                        
 
                        string a = textData[i];
                        String[] b = a.Split(' ');
                        dataTable1.Rows.Add(b);

                        for (int j = 0; j < daneStat.Count; j++)
                        {
                            string wartosc = b[j];
                            daneStat[j].Add(float.Parse(wartosc));

                            
                           
                            if (j==0)
                            {
                                Y[i - 1]=double.Parse(wartosc);
                            }
                             
                        }
                    }


                    dataGridDane.DataSource = dataTable1;
                    //Obliczanie sredniej
                    srednie = Obliczenia.Srednia(daneStat);

                    //Obliczanie wektora R0
                    r0 = Obliczenia.KorelacjaR0(daneStat);

                    //Wsadzanie R0 do grida w Form1
                    dataGridR0.Columns.Clear();
                    DataTable dataTable2 = new DataTable();
                    dataTable2.Columns.Add("R0", typeof(string), null);

                    for (int i = 0; i < r0.Count; i++)
                    {
                        dataTable2.Rows.Add(r0[i]);
                    }

                    dataGridR0.DataSource = dataTable2;

                    //------------------------------------------------

                    //Obliczanie macierzy R
                    r = Obliczenia.KorelacjaR(daneStat);

                    //Wsadzanie R do grida w Form1

                    //r[0,3]=0.1;
                   //r[1, 3] = 0.1;
                   // r[2, 3] = 0.1;
                
                    dataGridR.Columns.Clear();
                    DataTable dataTable3 = new DataTable();
                    for (int i = 1; i < headers.Length; i++)
                    {
                        dataTable3.Columns.Add(headers[i], typeof(string), null);
                    }

                    for (int i = 0; i < r.GetLength(0); i++)
                    {
                        string[] row = new string[r.GetLength(1)];
                        for (int j = 0; j < r.GetLength(1); j++)
                        {
                            row[j] = r[i, j].ToString();
                        }

                        dataTable3.Rows.Add(row);
                    }

                    dataGridR.DataSource = dataTable3;

                    //------------------------------------------------

                    //--Z tablic rozkładu t-Studenta odczytujemy wartość statystyki przy poziomie
                    //--istotności 0,05 oraz n-2
                    double t_a = Obliczenia.OdczytajT_alfa(daneStat[0].Count - 2);

                    //-----wartość krytyczna współczynnika korelacji 
                    double r_alfa = Obliczenia.ObliczR_alfa(t_a, daneStat[0].Count - 2);

                     //---zastepowanie zerem współczynników korelacji z R1 które są nieistotne

                    r_pi = r;

                     Obliczenia.Wspolczynniki_nieistotne(ref r_pi, r_alfa,ref graf);
                    //!-wspolcz_nieistotne


                    //z jakimi elementami w grafie powiązań łączy się np. x1 
                    Obliczenia.Powiazania(ref r_pi, ref graf);
                     

                    //--wyświeltenie tablicy powiązań w richtextbox1
                    int licznik = 0;
                 
                  richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                  richTextBox1.AppendText("Powiązania między zmiennymi objaśniającymi: " + "\n");
                  foreach (var x in graf)
                  {
                      licznik++;

                      richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
                      richTextBox1.AppendText("x" + licznik.ToString() + " " + "z" + ":  ");
                      foreach (var y in x)
                      {
                          richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                          richTextBox1.AppendText("x" + y.ToString() + ";  ");
                      }
                      richTextBox1.AppendText("\n");
                  }


                  //--- policzenie powiązań każdego x i zwrócenie maksymalnej liczby powiązań
                  double max=Obliczenia.Ile_powiazan(graf, ref ile_powiazan);

                  //--wyszukanie ile jest x`ów o maxymalnej liczbie powiązań i zwrócenie największej wartośći współczynnika korelacji
                 max=Obliczenia.Ile_X_o_max_powiazan(ref ile_powiazan, ref zwyciezcy,r0,max);

   
                 richTextBox1.AppendText("\n "); 

                 //wyszukaj maxymalną wartość współczynnika korelacji z x które się jeszcze liczą
                 Obliczenia.Max_wspolczynnik_korelacji(ile_powiazan, ref zwyciezcy, max);
                 

                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Do modelu zostaną zakwalifikowane zmienne: ");
                 foreach (var x in zwyciezcy)
                 {
                     richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Regular);
                     richTextBox1.AppendText("x" + x.ToString() + ";  ");

                 }

                 //------------------------------------------------
                    
                 //--macierzX z wybranych x
               dynamic X= new DenseMatrix(textData.Length - 1, zwyciezcy.Count + 1);
               Obliczenia.MacierzX(textData, zwyciezcy, ref X);

                 richTextBox1.AppendText("\n");
                 //--wyświetlenie macierzyY
                 richTextBox1.AppendText("\n");


                 //--macierz X transponowana
                 dynamic x_trans=0;

                 //--macierz X transponowana przemnożona przez macierz X
                 dynamic Xt_x_X = 0;

                 //--odwrotność Xt_x_X
                 dynamic Xt_x_X_invers = 0;

                //-- macierz X transponowana przemnożona przez wektor Y
                 dynamic X_trans_x_Y = 0; 

                 //--wyliczenie  parametrów strukturalnych
                 dynamic alfa = Obliczenia.param_strukturalne(X, Y, ref x_trans, ref Xt_x_X, ref X_trans_x_Y, ref Xt_x_X_invers);

                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Macierz transponowana X:");
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText(x_trans.ToString());

                 richTextBox1.AppendText("\n");

                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Macierz transponowana X przemnożona przez macierz X");
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText(Xt_x_X.ToString());

                 richTextBox1.AppendText("\n");

                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Macierz odwrotna");

                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText(Xt_x_X_invers.ToString());


                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Macierz X transponowana przemnożona przez wektor Y");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText("\n");
                 richTextBox1.AppendText(X_trans_x_Y.ToString());


                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Współczynniki alfa");
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText(alfa.ToString());

                 //-- wyliczenia składnika losowego
                 dynamic alfa_x_X = 0;
                 dynamic E = 0;
                 double suma=Obliczenia.Skladnik_losowy(X, alfa, Y, ref alfa_x_X,ref E);
               
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Wektor składników losowych");
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText(E.ToString());

                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Składnik losowy");
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);
                 richTextBox1.AppendText(suma.ToString());


                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 10, FontStyle.Bold);
                 richTextBox1.AppendText("Równanie modelu ekonometrycznego");
                 richTextBox1.AppendText("\n");
                 richTextBox1.SelectionFont = new System.Drawing.Font("Tahoma", 8, FontStyle.Regular);

                 richTextBox1.SelectionColor = Color.Red;
                 richTextBox1.AppendText("y =" + Math.Round(alfa[0], 5) + "+ ");
                 int kk=0;
                 for (int i = 1; i <= zwyciezcy.Count; i++)
                 {
                        
                     if (i == zwyciezcy.Count)
                     {
                         richTextBox1.AppendText(Math.Round(alfa[i], 5) + "x" + zwyciezcy[kk] + "+ " + Math.Round(suma, 5));
                     }
                     else
                     {
                         richTextBox1.AppendText(Math.Round(alfa[i], 5) + "x" + zwyciezcy[kk] + "+ ");
                     }
                     kk++;
                 }


                 //----------------------------------

                 //Wsadzanie R' do grida w Form1
                 dataGridR_pi.Columns.Clear();
                 DataTable dataTable4 = new DataTable();
                 for(int i = 1; i < headers.Length; i++)
                 {
                     dataTable4.Columns.Add(headers[i], typeof(string), null);
                 }

                 for (int i = 0; i < r_pi.GetLength(0); i++)
                 {
                     string[] row = new string[r_pi.GetLength(1)];
                     for(int j=0; j < r_pi.GetLength(1); j++)
                     {
                         row[j] = r_pi[i,j].ToString();
                     }

                     dataTable4.Rows.Add(row);
                 }

                 dataGridR_pi.DataSource = dataTable4;
             
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridDane_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuGornyPasek_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
    }
}
