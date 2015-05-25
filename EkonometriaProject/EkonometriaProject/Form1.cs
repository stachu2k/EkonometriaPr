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


namespace EkonometriaProject
{
    public partial class Form1 : Form
    {
        public List<List<double>> daneStat = new List<List<double>>();
        public List<double> srednie = new List<double>();
        public List<double> r0 = new List<double>();
        public List<List<double>> graf = new List<List<double>>();
        public List<double> ile_powiazan = new List<double>();
        public List<double> zwyciezcy = new List<double>();
        public double[,] r, r1;


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

                    for (int i = 1; i < textData.Length; i++)
                    {
                        string a = textData[i];
                        String[] b = a.Split(' ');
                        dataTable1.Rows.Add(b);

                        for (int j = 0; j < daneStat.Count; j++)
                        {
                            string wartosc = b[j];
                            daneStat[j].Add(float.Parse(wartosc));
                        }
                    }

                    dataGridDane.DataSource = dataTable1;

                    //------------------------------------------------

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
                    double t_a = Obliczenia.OdczytajT_alfa(daneStat, daneStat[0].Count - 2);

                    //-----wartość krytyczna współczynnika korelacji 
                    double r_alfa = Obliczenia.ObliczR_alfa(t_a, daneStat[0].Count - 2);

                     //---zastepowanie zerem współczynników korelacji z R1 które są nieistotne

                    r1 = r;

                    for (int i = 0; i < r1.GetLength(0); i++)
                    {
                        graf.Add(new List<double>());

                        for (int j = 0; j < r1.GetLength(0); j++)
                        {
                            if ((Math.Abs(r1[i, j]) <= r_alfa) && j>=i)
                            {
                                r1[i, j] = 0;
                            }

                            //--wszystko co pod przekątną to 0
                            if (j < i)
                            {
                                r1[i, j] = 0;
                            }
                        }
                    }

                    //z jakimi elementami w grafie powiązań łączy się np. x1 
                    for (int i = 0; i < r1.GetLength(0); i++)
                    {
                        for (int j = 0; j < r1.GetLength(0); j++)
                        {
                            //nie pobieraj 1 z przekątnej i nie pobieraj 0
                            if (j != i && (r1[i, j]!=0))
                            {
                                graf[j].Add(i+1);
                                graf[i].Add(j+1);
                            }
                        }
                    }

                    //--wyświeltenie tablicy powiązań w richtextbox1
                    int licznik = 0;

                    richTextBox1.AppendText("Powiązania między zmiennymi objaśniającymi: "+"\n"); 
                    foreach (var x in graf)
                    {
                        licznik++;
                        
                        richTextBox1.AppendText("x"+licznik.ToString()+" "+"z"+":  "); 
                        foreach (var y in x)
                        {
                            richTextBox1.AppendText("x"+y.ToString()+ ";  "); 
                        }
                        richTextBox1.AppendText("\n"); 
                    }

                    //--- policzenie powiązań każdego x
                    for (int i = 0; i < graf.Count;i++ )
                    {
                       int z=graf[i].Count;
                       ile_powiazan.Add(z);
                    }
                    double max= ile_powiazan.Max();

                    //richTextBox1.AppendText( "\n "); 

                    //--wyszukanie ile jest x`ów o maxymalnej liczbie powiązań
                    for (int i = 0; i < ile_powiazan.Count; i++)
                    {

                        // --zmienna izolowana zawsze wchodzi do modelu
                        if (ile_powiazan[i] == 0)
                        {
                            zwyciezcy.Add(i + 1);
                        }     
                        //---jeśli nie jest max to ustaw -5 (czyli całkowicie wyelminuj x z gry,bo korelacja chyba od -1 do 1)
                        else if(ile_powiazan[i]<max)
                        {
                            //--korelacja od -1 do 1?
                            ile_powiazan[i] = -5;

                       }
                        else{

                            //--- w przeciwnym wypadku podstaw pod powiązanie odpowiednik z R0
                             ile_powiazan[i]=r0[i];
                             //richTextBox1.AppendText(ile_powiazan[i].ToString() + ";  "); 
                        }
                    }

                    max = ile_powiazan.Max();
                    richTextBox1.AppendText("\n "); 

                    //wyszukaj maxymalną wartość współczynnika korelacji z x które się jeszcze liczą
                    for (int i = 0; i < ile_powiazan.Count; i++)
                    {
                        //--jeśli maxymalna liczba powiązań to 0, to x został już wcześniej dodany do zwyciezcy
                        if (ile_powiazan[i] >= max && ile_powiazan[i] != 0) //--!!!!!--
                        {
                            //---żeby wskazać zwyciezcę numerujemy kolumny 1,2,3,4 a nie 0,1,2,3
                           
                            zwyciezcy.Add(i + 1);
                          
                        }

                    }

                    richTextBox1.AppendText("Do modelu zostaną zakwalifikowane zmienne: "); 
                    foreach(var x in zwyciezcy)
                    {
                        richTextBox1.AppendText("x"+ x.ToString() + ";  "); 
                        
                    }

                    //------------------------------------------------

                    //Wsadzanie R' do grida w Form1
                    dataGridR_pi.Columns.Clear();
                    DataTable dataTable4 = new DataTable();
                    for(int i = 1; i < headers.Length; i++)
                    {
                        dataTable4.Columns.Add(headers[i], typeof(string), null);
                    }

                    for (int i = 0; i < r1.GetLength(0); i++)
                    {
                        string[] row = new string[r1.GetLength(1)];
                        for(int j=0; j < r1.GetLength(1); j++)
                        {
                            row[j] = r1[i,j].ToString();
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
        
    }
}
