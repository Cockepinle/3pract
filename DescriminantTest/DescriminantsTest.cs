using Discriminant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DescriminantTest
{
    [TestClass]
    public class DescriminantsTest
    {
        static List<double> prozent;
        private Descriminants _descriminant; 

        // Массив для хранения коэффициентов a, b, c
        private int[,] coefficients = new int[,]
        {
            { 1, 2, 5 },   // D < 0
            { 1, 2, 1 },   // D = 0
            { 1, -3, 2 }   // D > 0
        };

        [ClassInitialize]
        public static void InitializeCurrentTest(TestContext testContext)
        {
            prozent = new List<double>
            {
                15.0,
                25.0,
                40.0
            };
        }

        [TestInitialize]
        public void Des()
        {
            _descriminant = new Descriminants(); 
        }

        // Тест для D < 0
        [TestMethod]
        public void RootValues_Check_NullReturn()
        {
            int a = coefficients[0, 0], b = coefficients[0, 1], c = coefficients[0, 2]; // D < 0
            double?[] expectedRoots = { null, null };
            var (root1, root2) = _descriminant.RootValues(a, b, c);
            double?[] actualRoots = { root1, root2 };

            CollectionAssert.AreEqual(expectedRoots, actualRoots);
            CollectionAssert.AllItemsAreUnique(expectedRoots);
        }

        // Тест для D = 0
        [TestMethod]
        public void RootValues_Check_OneRootReturn()
        {
            int a = coefficients[1, 0], b = coefficients[1, 1], c = coefficients[1, 2]; // D = 0
            double expectedRoot = -1;
            double?[] expectedRoots = { expectedRoot, expectedRoot };

            var (root1, root2) = _descriminant.RootValues(a, b, c); 
            double?[] actualRoots = { root1, root2 };

            CollectionAssert.AreEqual(expectedRoots, actualRoots);
            CollectionAssert.AreEquivalent(expectedRoots, actualRoots);
        }

        // Тест для D > 0
        [TestMethod]
        public void RootValues_Check_TwoRootReturn()
        {
            int a = coefficients[2, 0], b = coefficients[2, 1], c = coefficients[2, 2]; // D > 0
            double[] expectedRoots = { 2, 1 };

            var (root1, root2) = _descriminant.RootValues(a, b, c); 

            double[] actualRoots = { root1.Value, root2.Value };

            CollectionAssert.AreEqual(expectedRoots, actualRoots);
            CollectionAssert.IsSubsetOf(expectedRoots, actualRoots);
        }

        // Тест для вычисления процента от числа с дельтой
        [TestMethod]
        public void PercentageOfTheNumber_Check_ReturnProzent()
        {
            double number = 200;
            double percentage = prozent[0];
            double expectedValue = number * (percentage / 100);

            double result = _descriminant.PercentageOfTheNumber(number, percentage); 

            double delta = 0.01;

            Assert.AreEqual(expectedValue, result, delta);
        }
    }
}