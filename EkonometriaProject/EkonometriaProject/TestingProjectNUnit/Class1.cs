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
    }
}
