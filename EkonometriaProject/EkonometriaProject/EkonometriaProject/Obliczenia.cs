using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;



namespace EkonometriaProject
{
    public static class Obliczenia
    {
        public static List<double> Srednia(List<List<double>> daneStat)
        {
            List<double> srednie = new List<double>();
            double suma;

            for (int i = 0; i < daneStat.Count; i++)
            {
                suma = 0;
                int ile_wWierszu = daneStat[i].Count;
                for (int j = 0; j < ile_wWierszu; j++)
                {
                    suma = suma + daneStat[i][j];
                }

                suma = suma / (ile_wWierszu)*1.0;
                srednie.Add(suma);
            }

            return srednie;
        }

        public static List<double> KorelacjaR0(List<List<double>> daneStat)
        {

            List<double> r0 = new List<double>();

            for (int i = 1; i < daneStat.Count; i++)
            {
                r0.Add(Correlation.Pearson(daneStat[i], daneStat[0]));
            }

            return r0;
        }

        public static double[,] KorelacjaR(List<List<double>> daneStat)
        {
            double[][] daneArray = new double[daneStat.Count-1][];
            for(int i = 1; i < daneStat.Count; i++)
            {
                daneArray[i-1] = new double[daneStat[i].Count];
                daneArray[i-1] = daneStat[i].ToArray();
            }
            var r_matrix = Correlation.PearsonMatrix(daneArray);
            double[,] r = r_matrix.ToArray();
            return r;
        }

        public static double OdczytajT_alfa(int s_swobody)
        {
            //--Z tablic rozkładu t-Studenta odczytujemy wartość statystyki przy poziomie
            //--istotności 0,05 oraz n-2
            double alfa = 0.05;

            double t_a = ExcelFunctions.TInv(alfa, s_swobody);
            return t_a;
        }

        public static double ObliczR_alfa(double t_a, int s_swobody)
        {
            double r_alfa;
            r_alfa = Math.Sqrt((Math.Pow(t_a, 2)) / (s_swobody + (Math.Pow(t_a, 2))));
            return r_alfa;
        }


        public static void Wspolczynniki_nieistotne(ref double[,] r_pi, double r_alfa, ref List<List<double>> graf)
        {

            for (int i = 0; i < r_pi.GetLength(0); i++)
            {
                graf.Add(new List<double>());

                for (int j = 0; j < r_pi.GetLength(0); j++)
                {
                    if ((Math.Abs(r_pi[i, j]) <= r_alfa) && j >= i)
                    {
                        r_pi[i, j] = 0;
                    }

                    //--wszystko co pod przekątną to 0
                    if (j < i)
                    {
                        r_pi[i, j] = 0;
                    }
                }
            }

          
        }

          public static void Powiazania(ref double[,] r_pi,ref List<List<double>> graf)
        {
            for (int i = 0; i < r_pi.GetLength(0); i++)
            {


                for (int j = 0; j < r_pi.GetLength(0); j++)
                {
                    //nie pobieraj 1 z przekątnej i nie pobieraj 0
                    if (j != i && (r_pi[i, j] != 0))
                    {
                        graf[j].Add(i + 1);
                        graf[i].Add(j + 1);
                    }
                }
            }

          }
       
          public static double Ile_powiazan( List<List<double>> graf,ref List<double> ile_powiazan)
          {
              double max;
              for (int i = 0; i < graf.Count; i++)
              {
                  int z = graf[i].Count;
                  ile_powiazan.Add(z);
              }

              //---największa liczba powiązań
             return max = ile_powiazan.Max();

          }

        
          public static double Ile_X_o_max_powiazan(ref List<double> ile_powiazan, ref List<int> zwyciezcy,List<double> r0,double max)
          {

             
                for (int i = 0; i < ile_powiazan.Count; i++)
                 {

                     // --zmienna izolowana zawsze wchodzi do modelu
                     if (ile_powiazan[i] == 0)
                     {
                         zwyciezcy.Add(i + 1);
                     }     
                     //---jeśli nie jest max to ustaw -5 (czyli całkowicie wyelminuj x z gry,bo korelacja  od -1 do 1)
                     else if(ile_powiazan[i]<max)
                     {
                       
                         ile_powiazan[i] = -5;

                    }
                     else{

                         //--- w przeciwnym wypadku podstaw pod powiązanie odpowiednik z R0
                          ile_powiazan[i]=r0[i];
                          //richTextBox1.AppendText(ile_powiazan[i].ToString() + ";  "); 
                     }
                 }

                max = ile_powiazan.Max();
                return max;
          }


          public static void Max_wspolczynnik_korelacji(List<double> ile_powiazan, ref List<int> zwyciezcy,  double max)
          {

              for (int i = 0; i < ile_powiazan.Count; i++)
              {
                  //--jeśli maxymalna liczba powiązań to 0, to x został już wcześniej dodany do zwyciezcy
                  if (ile_powiazan[i] >= max && ile_powiazan[i] != 0) //--!!!!!--
                  {
                      //---żeby wskazać zwyciezcę numerujemy kolumny 1,2,3,4 a nie 0,1,2,3

                      zwyciezcy.Add(i + 1);

                  }

              }
          }

        
          public static void MacierzX(string[] textData, List<int> zwyciezcy, ref dynamic X)
          {

          
              //--przechodzi po wierszach
              for (int k = 1; k < textData.Length; k++)
              {
                  X[k - 1, 0] = 1;
                  //-- przechodzi po wybranych X
                  for (int i = 0; i < zwyciezcy.Count; i++)
                  {

                      string a = textData[k];
                      string[] b = a.Split(' ');

                      X[k - 1, i + 1] = Convert.ToDouble(b[zwyciezcy[i]]);


                  }

              }
             
          }

          public static dynamic param_strukturalne(dynamic X, dynamic Y, ref dynamic x_trans, ref dynamic Xt_x_X, ref dynamic X_trans_x_Y, ref dynamic Xt_x_X_invers)
          {
               x_trans = X.Transpose();
               Xt_x_X = x_trans.Multiply(X);
              Xt_x_X_invers = Xt_x_X.Inverse();
               X_trans_x_Y = x_trans.Multiply(Y);
               dynamic alfa = Xt_x_X_invers.Multiply(X_trans_x_Y);
              return alfa;

          }

        public static double Skladnik_losowy(dynamic X,dynamic alfa,dynamic Y,ref dynamic alfa_x_X, ref dynamic E)
          {
              alfa_x_X = X.Multiply(alfa);
             E = Y.Subtract(alfa_x_X);

              double suma = 0;
              foreach (var x in E)
              {
                  suma = suma + Math.Pow(x, 2);
              }
              return suma;
        }
          
    }
}
