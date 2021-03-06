namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using Grupp9Hushallsekonomi.Interface;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SumOfIncomeTests
    {
        private readonly BudgetCalculator bc = new BudgetCalculator();
        private const double Expected = 0;

        [SetUp]
        public void SetUp()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);
        }

        [Test]
        public void SumOfIncome_01_ChecksIfIncomeIsLessOrEqualToZero_ReturnFalse()
        {
            BudgetCalculator.listOfEconomy.Add(new Income { Name = "Test", Money = double.MinValue });
            var income = bc.SumOfIncome(BudgetCalculator.listOfEconomy);
            var actual = income < 0;
            Assert.IsFalse(actual);
        }

        [Test]
        public void SumOfIncome_02_CheckIfNoIncomeExists_ReturnsEqual()
        {
            var listOfExpenses = new List<IAccount> { new Expense { Name = "TestExpense", Money = 500 } };
            var actual = bc.SumOfIncome(listOfExpenses);
            Assert.AreEqual(actual, Expected);
        }

        [Test]
        public void SumOfIncome_03_CheckIfListIsNull_ReturnsEqual()
        {
            var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SumOfIncome(nullList);
            Assert.AreEqual(actual, Expected);
        }

        [Test]
        public void SumOfIncome_04_CheckIfListPropertyIsNull_ReturnsEqual()
        {
            var nullProperyList = new List<IAccount>{ new Income() };
            var actual = bc.SumOfIncome(nullProperyList);
            Assert.AreEqual(actual, Expected);
        }

        [TearDown]
        public void Clear()
        {
            BudgetCalculator.listOfEconomy.Clear();
            BudgetCalculator.totalIncome.Money = 0;
            BudgetCalculator.totalExpense.Money = 0;
        }
    }
}