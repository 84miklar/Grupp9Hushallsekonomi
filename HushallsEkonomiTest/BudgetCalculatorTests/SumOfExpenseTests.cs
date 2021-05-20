namespace HushallsEkonomiTest.BudgetCalculatorTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Helpers;
    using Grupp9Hushallsekonomi.Interface;
    using NUnit.Framework;
    using System.Collections.Generic;
    public class SumOfExpenseTests
    {
        private readonly BudgetCalculator bc = new BudgetCalculator();
        private const double expected = 0;
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
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void SumOfExpense_02_CheckIfListIsNull_ReturnsEqual()
        {
            var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SumOfExpense(nullList);
            Assert.AreEqual(actual, expected);
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
