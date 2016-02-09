using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarkIt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkIt.Tests
{
    [TestClass()]
    public class AverageNumberTests
    {
        [TestMethod()]
        public void AddValueTest()
        {
            var an = new AverageNumber(new[] { 5.0 });

            Assert.AreEqual(an.High, 5.0);
            Assert.AreEqual(an.Low, 5.0);
            Assert.AreEqual(an.Average, 5.0);

            an.Replace(new[] { 20.0, 30.0 });
            
            Assert.AreEqual(an.High, 30.0);
            Assert.AreEqual(an.Low, 20.0);
            Assert.AreEqual(an.Average, 25.0);

            Random rand = new Random();
            for(var i = 0; i < 100; i++)
            {
                var size = rand.Next(90) + 10;
                var arr = new double[size];

                for(var j = 0; j < size; j++)
                {
                    arr[j] = rand.NextDouble();
                }

                an = new AverageNumber(arr);

                Assert.IsTrue(AlmostEqual(an.High, arr.Max()), $"Expected: {an.High}, Actual: {arr.Max()}, {double.Epsilon}");
                Assert.IsTrue(AlmostEqual(an.Low, arr.Min()), $"Expected: {an.Low}, Actual: {arr.Min()}, {double.Epsilon}");
                Assert.IsTrue(AlmostEqual(an.Average, arr.Average()), $"Expected: {an.Average}, Actual: {arr.Average()}, {double.Epsilon}");
            }
        }

        private const double _EPSILON = 0.000001;
        private bool AlmostEqual(double a, double b)
        {
            return Math.Abs(a - b) < _EPSILON;
        }
    }
}