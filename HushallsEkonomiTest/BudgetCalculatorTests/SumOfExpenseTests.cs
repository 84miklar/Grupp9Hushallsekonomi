namespace HushallsEkonomiTest.BudgetCalculatorTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using Grupp9Hushallsekonomi.Interface;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SumOfExpenseTests
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
        public void SumOfExpense_01_CheckIfNoExpensesExists_ReturnsEqual()
        {
            var listWithOnlyIncome = new List<IAccount> { new Income { Name = "Test", Money = 500 } };
            var actual = bc.SumOfExpense(listWithOnlyIncome);
            Assert.AreEqual(actual, Expected);
        }

        [Test]
        public void SumOfExpense_02_CheckIfListIsNull_ReturnsEqual()
        {
            var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SumOfExpense(nullList);
            Assert.AreEqual(actual, Expected);
        }
        [Test]
        public void SumOfExpense_03_CheckIfListPropertyIsNull_ReturnsEqual()
        {
            var nullPropertyList = new List<IAccount> {new Expense()};
            var actual = bc.SumOfExpense(nullPropertyList);
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