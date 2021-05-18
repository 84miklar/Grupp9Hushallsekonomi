using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Helpers;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HushallsEkonomiTest
{
    class SumOfIncomeTests
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
        public void SumOfIncome_01_ChecksIfIncomeIsLessOrEqualToZero_ReturnFalse()
        {
            BudgetCalculator.listOfEconomy.Add(new Income { Name = "Test", Money = double.MinValue });
            var income = bc.SumOfIncome(BudgetCalculator.listOfEconomy);
            var actual = income <= 0;
            Assert.IsFalse(actual);
        }
        [Test]
        public void SumOfIncome_02_CheckIfNoIncomeExists_ReturnsZero()
        {
            var income = BudgetCalculator.listOfEconomy.FirstOrDefault(x => x is Income);
            BudgetCalculator.listOfEconomy.Remove(income);
            var actual = bc.SumOfIncome(BudgetCalculator.listOfEconomy);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void SumOfIncome_03_CheckIfListIsNull_ReturnsEqual()
        {
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SumOfIncome(nullList);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }
    }
}
