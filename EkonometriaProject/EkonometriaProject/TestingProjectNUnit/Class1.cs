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

        [Test]
        public void TestObliczeniaIle_powiazan()
        {
            /*
             * badane listy:
             *          graf:
             *              [0] = 2.0 , 3.0 , 4.0
             *              [1] = 1.0 , 3.0 , 4.0
             *              [2] = 1.0 , 2.0 , 4.0
             *              [3] = 1.0 , 2.0 , 3.0
             * 
             * oczekiwany rezultat:
             *          max: 3.0
             *          ile_powiazan:
             *              < 3.0 , 3.0 , 3.0 , 3.0 >
             */
            List<List<double>> graf = new List<List<double>>();
            for (int i = 0; i < 4; i++)
            {
                graf.Add(new List<double>());
            }
            graf[0].Add(2.0);
            graf[0].Add(3.0);
            graf[0].Add(4.0);
            graf[1].Add(1.0);
            graf[1].Add(3.0);
            graf[1].Add(4.0);
            graf[2].Add(1.0);
            graf[2].Add(2.0);
            graf[2].Add(4.0);
            graf[3].Add(1.0);
            graf[3].Add(2.0);
            graf[3].Add(3.0);

            List<double> ile_powiazan = new List<double>();
            List<double> ilePowiazan = new List<double>();
            ilePowiazan.Add(3.0);
            ilePowiazan.Add(3.0);
            ilePowiazan.Add(3.0);
            ilePowiazan.Add(3.0);

            double oczekiwanaWartosc = 3.0;

            double result = Obliczenia.Ile_powiazan(graf, ref ile_powiazan);

            Assert.AreEqual(oczekiwanaWartosc, result);
            Assert.AreEqual(ilePowiazan, ile_powiazan);
        }

        [Test]
        public void TestObliczeniaIle_X_o_max_powiazan()
        {
            /*
             * badane:
             *          ile_powiazan: < 3.0 , 3.0 , 3.0 , 3.0 >
             *          zwyciezcy: < >
             *          r0: < 0.91898997058445764 , 0.8954598307308107 , 0.876974745235139 , 0.917413800307416 >
             *          max: 3.0
             * 
             * oczekiwany rezultat:
             *          max: 0.91898997058445764
             *          ile powiazan: < 0.91898997058445764 , 0.8954598307308107 , 0.876974745235139 , 0.917413800307416 >
             *          zwyciezcy: < >
             */
            List<double> ile_powiazan = new List<double>();
            ile_powiazan.Add(3.0);
            ile_powiazan.Add(3.0);
            ile_powiazan.Add(3.0);
            ile_powiazan.Add(3.0);
            List<double> ile_powiazan2 = new List<double>();
            ile_powiazan2.Add(0.91898997058445764);
            ile_powiazan2.Add(0.8954598307308107);
            ile_powiazan2.Add(0.876974745235139);
            ile_powiazan2.Add(0.917413800307416);
            List<int> zwyciezcy = new List<int>();
            List<int> zwyciezcy2 = new List<int>();
            List<double> r0 = new List<double>();
            r0.Add(0.91898997058445764);
            r0.Add(0.8954598307308107);
            r0.Add(0.876974745235139);
            r0.Add(0.917413800307416);
            double max = 3.0;
            double oczekiwanaWartosc = 0.91898997058445764;

            double result = Obliczenia.Ile_X_o_max_powiazan(ref ile_powiazan, ref zwyciezcy, r0, max);

            Assert.AreEqual(oczekiwanaWartosc, result);
            Assert.AreEqual(ile_powiazan, ile_powiazan2);
            Assert.AreEqual(zwyciezcy, zwyciezcy2);
        }
    }
}
