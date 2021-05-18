using Grupp9Hushallsekonomi.Account;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HushallsEkonomiTest
{
    class CalculatePercentageToMoneyTests
    {
        [Test]
        [TestCase(1000, 500)]
        [TestCase(500, 250)]
        [TestCase(100, 50)]
        public void CalculatePercentageToMoney_01_CheckPercentageValuePositiveInput_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(-546049, 0)]
        [TestCase(0, 0)]
        [TestCase(-10, 0)]
        public void CalculatePercentageToMoney_02_CheckPercentageValueNegativeInput_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }
    }
}
