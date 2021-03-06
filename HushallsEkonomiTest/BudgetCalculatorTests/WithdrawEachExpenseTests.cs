namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using Grupp9Hushallsekonomi.Interface;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class WithdrawEachExpenseTests
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
        public void WithdrawEachExpense_01_CheckIfWithdrawIsSucessfull_ReturnsEqual()
        {
            var expected = Withdraw();
            var actual = bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawEachExpense_02_CheckIfListIsNull_ReturnEqual()
        {
            var expected = 0;
            var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.WithdrawEachExpense(nullList);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(double.MaxValue)]
        [Test]
        public void WithdrawEachExpense_03_CheckExpenseLargerThanIncome_ReturnEqual(double outcome)
        {
            var expected = Withdraw();
            BudgetCalculator.listOfEconomy.Add(new Expense { Name = "VeryLargeBill", Money = outcome });
            var actual = bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void WithdrawEachExpense_04_CheckIfListIsEmpty_ReturnEqual()
        {
            var emptyList = new List<IAccount>();
            var actual = bc.WithdrawEachExpense(emptyList);
            var expected = BudgetCalculator.totalIncome.Money;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void WithdrawEachExpense_05_CheckIfListPropertyIsEmpty_ReturnEqual()
        {
            var testList = new List<IAccount>{ new Expense(), new Income() };
            var bc = new BudgetCalculator();
            BudgetCalculator.totalIncome.Money = 0;
            var actual = bc.WithdrawEachExpense(testList);
            var expected = 0;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        /// Method that returns money left on account by calculate incomes minus expenses.
        /// </summary>
        /// <returns>money left on account</returns>
        private double Withdraw()
        {
            return BudgetCalculator.totalIncome.Money - BudgetCalculator.totalExpense.Money;
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