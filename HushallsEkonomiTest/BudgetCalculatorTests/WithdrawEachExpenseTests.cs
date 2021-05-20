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
        public void WithdrawEachExpense_02_CheckIfListIsNull_ReturnNotEqual()
        {
            var expected = Withdraw();
            var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.WithdrawEachExpense(nullList);
            Assert.AreNotEqual(expected, actual);
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

        /// <summary>
        /// Metod som returnerar pengar man har kvar på kontot genom att beräkna inkomsterna minus utgifterna
        /// </summary>
        /// <returns>pengar kvar på kontot</returns>
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
