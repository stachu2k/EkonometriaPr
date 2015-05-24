using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EkonometriaProject
{
    public partial class Form1 : Form
    {
        public List<List<double>> daneStat = new List<List<double>>();
        public List<double> srednie = new List<double>();
        public List<double> r0 = new List<double>();
        public double[,] r;


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

                    //Obliczanie macierzy R
                    r = Obliczenia.KorelacjaR(daneStat);

                    //Wsadzanie R do grida w Form1
                    dataGridR.Columns.Clear();
                    DataTable dataTable3 = new DataTable();
                    for(int i = 1; i < headers.Length; i++)
                    {
                        dataTable3.Columns.Add(headers[i], typeof(string), null);
                    }

                    for (int i = 0; i < r.GetLength(0); i++)
                    {
                        string[] row = new string[r.GetLength(1)];
                        for(int j=0; j < r.GetLength(1); j++)
                        {
                            row[j] = r[i,j].ToString();
                        }

                        dataTable3.Rows.Add(row);
                    }

                    dataGridR.DataSource = dataTable3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
    }
}
