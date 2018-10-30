using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Server
{
    [TestClass]
    class Unittest
    {
        private double Grams=10;
        private double Ounces=0.35274;
        private Convertions convertions;

        [TestInitialize]
        public void BeforeTest()
        {
            convertions = new Convertions();
        }

        [TestMethod]
        public void TestGramsToOunces()
        {
            Assert.AreEqual(convertions.GramsToOunces(this.Grams), this.Ounces);
        }

        [TestMethod]
        public void TestOuncesToGrams()
        {
            Assert.AreEqual(convertions.OuncesToGrams(this.Ounces), this.Grams);
        }
    }
}
