using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HushallsEkonomiTest
{
    class CalculatePercentageToMoneyTests
    {
        BudgetCalculator bc = new BudgetCalculator();
        [SetUp]
        public void SetUp()
        {
            Seeder seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithOutcome();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);

        }
        [TearDown]
        public void Clear()
        {
            BudgetCalculator.listOfEconomy.Clear();
            BudgetCalculator.totalIncome.Money = 0;
            BudgetCalculator.totalExpense.Money = 0;
        }
        [Test]
        [TestCase(1000, 500)]
        [TestCase(500, 250)]
        [TestCase(100, 50)]
        public void CalculatePercentageToMoney_01_CheckPercentageValuePositiveInput_ReturnEqual(double income, double expected)
        {
            Saving savings = new Saving("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(-546049, 0)]
        [TestCase(0, 0)]
        [TestCase(-10, 0)]
        public void CalculatePercentageToMoney_02_CheckPercentageValueNegativeInput_ReturnEqual(double income, double expected)
        {
            Saving savings = new Saving("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }
    }
}
