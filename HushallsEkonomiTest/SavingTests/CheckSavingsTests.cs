namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class CheckSavingsTests
    {
        private readonly BudgetCalculator bc = new BudgetCalculator();

        [SetUp]
        public void SetUp()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);
            seeder.FillListWithSavings();
        }

        [Test]
        public void CheckSavings_01_ChecksSuccessfulWithdraw_ReturnTrue()
        {
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            var actual = Saving.CheckSavings(BudgetCalculator.savingsList);
            Assert.IsTrue(actual);
        }

        [Test]
        public void CheckSavings_02_ChecksUnsuccessfulWithdraw_ReturnFalse()
        {
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.totalIncome.Money = 0;
            var actual = Saving.CheckSavings(BudgetCalculator.savingsList);
            Assert.IsFalse(actual);
        }

        [Test]
        public void CheckSavings_03_ChecksIfPercentageIsOverMaxPercentage_ReturnEqual()
        {
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.savingsList.Add(new Saving { Name = "Error", SavingsPercentage = 1.1 });
            var actual = Saving.CheckSavings(BudgetCalculator.savingsList);
            var expected = BudgetCalculator.totalIncome.Money >= 0;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void CheckSavings_04_ChecksIfListIsNull_ReturnFalse()
        {
            var nullList = new List<Saving>();
            nullList = null;
            var actual = Saving.CheckSavings(nullList);
            Assert.IsFalse(actual);
        }

        [Test]
        public void CheckSavings_05_ChecksIfListIsEmpty_ReturnFalse()
        {
            var emptyList = new List<Saving>();
            var actual = Saving.CheckSavings(emptyList);
            Assert.IsFalse(actual);
        }
        [Test]
        public void CheckSavings_06_ChecksIfListPropertyIsEmpty_ReturnTrue()
        {
            var emptyList = new List<Saving> { new Saving {Name = null, SavingsPercentage = 0.1} };
            var actual = Saving.CheckSavings(emptyList);
            Assert.IsTrue(actual);
        }
        [Test]
        public void CheckSavings_07_ChecksIfListPropertyIsEmpty_ReturnFalse()
        {
            var emptyList = new List<Saving> { null } ;
            var actual = Saving.CheckSavings(emptyList);
            Assert.IsFalse(actual);
        }
        [TearDown]
        public void Clear()
        {
            BudgetCalculator.listOfEconomy.Clear();
            BudgetCalculator.savingsList.Clear();
            BudgetCalculator.totalIncome.Money = 0;
            BudgetCalculator.totalExpense.Money = 0;
        }
    }
}