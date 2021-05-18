using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest
{
    public class WithdrawEachExpenseTests
    {
        BudgetCalculator bc = new BudgetCalculator();
        [Test]
        public void WithdrawEachExpense_01_CheckIf()
        {
            var expected = Withdraw();
            var actual = bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawEachExpense_02_CheckIfListIsNull_ReturnNotEqual()
        {
            var expected = Withdraw();
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.WithdrawEachExpense(nullList);
            Assert.AreNotEqual(expected, actual);
        }

        [TestCase(double.MaxValue)]
        [Test]
        public void WithdrawEachExpense_03_CheckOutcomeLargerThanIncome_ReturnEqual(double outcome)
        {
            var expected = Withdraw();
            BudgetCalculator.listOfEconomy.Add(new Expense() { Name = "VeryLargeBill", Money = outcome });
            var actual = bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// Metod som returnerar pengar man har kvar på kontot genom att beräkna inkomsterna minus utgifterna
        /// </summary>
        /// <returns>pengar kvar på kontot</returns>
        public double Withdraw()
        {
            return BudgetCalculator.totalIncome.Money - BudgetCalculator.totalExpense.Money;
        }
    }
}
