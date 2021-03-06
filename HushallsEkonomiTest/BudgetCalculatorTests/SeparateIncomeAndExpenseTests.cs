namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using Grupp9Hushallsekonomi.Interface;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SeparateIncomeAndExpenseTests
    {
        private readonly BudgetCalculator bc = new BudgetCalculator();

        [SetUp]
        public void SetUp()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);
        }

        [Test]
        public void SeparateIncomeAndExpense_01_CheckIfListIsNull_ReturnNull()
        {
            var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SeparateIncomeAndExpense(nullList);
            Assert.IsNull(actual);
        }

        [Test]
        public void SeparateIncomeAndExpense_02_CheckIfListIsEmpty_ReturnIsEmpty()
        {
            var emptyList = new List<IAccount>();
            var actual = bc.SeparateIncomeAndExpense(emptyList);
            Assert.IsEmpty(actual);
        }
        [Test]
        public void SeparateIncomeAndExpense_03_CheckIfListPropertyIsEmpty_ReturnEqual()
        {
            var emptyList = new List<IAccount> {null};
            BudgetCalculator.totalExpense.Money = 0;
            BudgetCalculator.totalIncome.Money = 0;
            bc.SeparateIncomeAndExpense(emptyList);
            var expected = 0;
            Assert.AreEqual(expected, BudgetCalculator.totalExpense.Money);
            Assert.AreEqual(expected, BudgetCalculator.totalIncome.Money);
        }
        [Test]
        public void SeparateIncomeAndExpense_04_CheckIfListPropertyIsEmpty_ReturnEqual()
        {
            var emptyList = new List<IAccount> {new Expense(), new Income() };
            BudgetCalculator.totalExpense.Money = 0;
            BudgetCalculator.totalIncome.Money = 0;
            bc.SeparateIncomeAndExpense(emptyList);
            var expected = 0;
            Assert.AreEqual(BudgetCalculator.totalExpense.Money, expected);
            Assert.AreEqual(BudgetCalculator.totalIncome.Money, expected);
        }

        [TearDown]
        public void Clear()
        {
            BudgetCalculator.succesfulWithdrawns.Clear();
            BudgetCalculator.listOfEconomy.Clear();
            BudgetCalculator.totalIncome.Money = 0;
            BudgetCalculator.totalExpense.Money = 0;
        }
    }
}