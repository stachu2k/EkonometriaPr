using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using EkonometriaProject;

namespace TestingProjectNUnit
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestObliczeniaSrednia()
        {
            /*
             * badane listy:
             *          lista1: < 1.0 , 2.0 >
             *          lista2: < 2.0 , 3.0 >
             * 
             * oczekiwany rezultat:
             *          < 1.5 , 2.5 >
             */
            List<List<double>> daneStat = new List<List<double>>();
            List<double> oczekiwaneSrednie = new List<double>();
            oczekiwaneSrednie.Add(1.5);
            oczekiwaneSrednie.Add(2.5);

            for(int i=0; i<2; i++)
            {
                daneStat.Add(new List<double>());
            }
            for(int i=0; i<daneStat.Count; i++)
            {
                double[] row = new double[2] {(i+1)*1.0, (i+2)*1.0};
                for(int j=0; j<row.Length; j++)
                {
                    daneStat[j].Add(row[j]);
                }
            }

            List<double> result = Obliczenia.Srednia(daneStat);

            Assert.AreEqual(oczekiwaneSrednie, result);
        }

        [Test]
        public void TestObliczeniaKorelacjaR0()
        {
            /*
             * badane listy:
             *          lista1: < 1.0 , 2.0 >
             *          lista2: < 2.0 , 3.0 >
             * 
             * oczekiwany rezultat:
             *          < 1.0 >
             */
            List<List<double>> daneStat = new List<List<double>>();
            List<double> oczekiwanaKorelacja = new List<double>();
            oczekiwanaKorelacja.Add(1.0);

            for (int i = 0; i < 2; i++)
            {
                daneStat.Add(new List<double>());
            }
            for (int i = 0; i < daneStat.Count; i++)
            {
                double[] row = new double[2] { (i + 1) * 1.0, (i + 2) * 1.0 };
                for (int j = 0; j < row.Length; j++)
                {
                    daneStat[j].Add(row[j]);
                }
            }

            List<double> result = Obliczenia.KorelacjaR0(daneStat);

            Assert.AreEqual(oczekiwanaKorelacja, result);
        }

        [Test]
        public void TestObliczeniaKorelacjaR()
        {
            /*
             * badane listy:
             *          lista1: < 1.0 , 2.0 >
             *          lista2: < 2.0 , 3.0 >
             *          lista3: < 3.0 , 4.0 >
             * 
             * oczekiwany rezultat:
             *          [ 1.0 , 1.0
             *            1.0 , 1.0 ]
             */
            List<List<double>> daneStat = new List<List<double>>();
            double[,] oczekiwanaKorelacja = new double[2, 2] { { 1.0, 1.0 }, { 1.0, 1.0 } };

            for (int i = 0; i < 3; i++)
            {
                daneStat.Add(new List<double>());
            }
            for (int i = 0; i < daneStat.Count; i++)
            {
                double[] row = new double[3] { (i + 1) * 1.0, (i + 2) * 1.0, (i + 3) * 1.0 };
                for (int j = 0; j < row.Length; j++)
                {
                    daneStat[j].Add(row[j]);
                }
            }
            
            double[,] result = Obliczenia.KorelacjaR(daneStat);

            Assert.AreEqual(oczekiwanaKorelacja, result);
        }

        [Test]
        public void TestObliczeniaOdczytajT_alfa()
        {
            int st_swobody = 30;
            double oczekiwanaWartosc = 2.042;

            double result = Obliczenia.OdczytajT_alfa(st_swobody);
            result = Math.Round(result, 3);

            Assert.AreEqual(oczekiwanaWartosc, result);
        }

        [Test]
        public void TestObliczeniaObliczR_alfa()
        {
            double t_a = 2.042;
            int st_swobody = 30;
            double oczekiwanaWartosc = 0.35;

            double result = Obliczenia.ObliczR_alfa(t_a, st_swobody);
            result = Math.Round(result, 2);

            Assert.AreEqual(oczekiwanaWartosc, result);
        }
    }
}
