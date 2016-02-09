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
    public class NonNegativeAverageNumberTests
    {
        [TestMethod()]
        public void AddValueTest()
        {
            var an = new NonNegativeAverageNumber(new[] { 5.0 });

            Assert.AreEqual(an.High, 5.0);
            Assert.AreEqual(an.Low, 5.0);
            Assert.AreEqual(an.Average, 5.0);

            an.Replace(new[] { 20.0, 30.0 });

            Assert.AreEqual(an.High, 30.0);
            Assert.AreEqual(an.Low, 20.0);
            Assert.AreEqual(an.Average, 25.0);

            an.Replace(new[] { -100.0, 5.0 });

            Assert.AreEqual(an.High, 5.0);
            Assert.AreEqual(an.Low, -100.0);
            Assert.AreEqual(an.Average, 5.0);

            an.Replace(new[] { -123.0, -10.0, -1.0 });
            
            Assert.AreEqual(an.High, -1.0);
            Assert.AreEqual(an.Low, -123.0);
            Assert.AreEqual(an.Average, 0.0);
        }
    }
}