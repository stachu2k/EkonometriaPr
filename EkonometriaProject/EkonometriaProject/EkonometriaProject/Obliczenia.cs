using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.LinearAlgebra;

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

        public static double OdczytajT_alfa(List<List<double>> daneStat, int s_swobody)
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
    }
}
