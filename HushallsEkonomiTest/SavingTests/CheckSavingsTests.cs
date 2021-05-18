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
    public class CheckSavingsTests
    {
        
        BudgetCalculator bc = new BudgetCalculator();
        Saving savings = new Saving();

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
        public void CheckSavings_01_ChecksSuccessfullWithdraw_ReturnTrue()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            Assert.IsTrue(actual);
        }

        [Test]
        public void CheckSavings_02_ChecksUnsuccessfullWithdraw_ReturnFalse()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.totalIncome.Money = 0;
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            Assert.IsFalse(actual);
        }

        [Test]
        public void CheckSavings_03_ChecksIfPrecentageIsOverMaxPercentage_ReturnEqual()
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
        public void CheckSavings_04_ChecksIfListIsNull_ReturnFalse()
        {
            List<Saving> nullList = new List<Saving>();
            nullList = null;
            var actual = savings.CheckSavings(nullList);
            Assert.IsFalse(actual);
        }
    }
}
