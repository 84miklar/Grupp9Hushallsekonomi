using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest
{
    public class SavingTests
    {
        BudgetCalculator bc = new BudgetCalculator();
        Saving savings = new Saving();
        [Test]
        public void Savings_01_ChecksSuccessfullWithdraw_ReturnTrue()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            Assert.IsTrue(actual);
        }

        [Test]
        public void Savings_02_ChecksUnsuccessfullWithdraw_ReturnFalse()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.totalIncome.Money = 0;
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Savings_03_ChecksIfPrecentageIsOverMaxPercentage_ReturnEqual()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.savings.Add(new Saving("Error", 1.1));
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            var expected = BudgetCalculator.totalIncome.Money >= 0;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Savings_04_ChecksIfListIsNull_ReturnFalse()
        {
            List<Saving> nullList = new List<Saving>();
            nullList = null;
            var actual = savings.CheckSavings(nullList);
            Assert.IsFalse(actual);
        }
    }
}
