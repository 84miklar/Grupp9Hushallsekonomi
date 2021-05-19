using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Helpers;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.BudgetCalculatorTests
{
    public class SumOfExpenseTests
    {
        BudgetCalculator bc = new BudgetCalculator();

        [SetUp]
        public void SetUp()
        {
            Seeder seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
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
        public void SumOfExpense_01_CheckIfNoExpensesExists_ReturnsEqual()
        {

            var listWithOnlyIncome = new List<IAccount>() { new Income { Name = "Test", Money = 500 } };
            var actual = bc.SumOfExpense(listWithOnlyIncome);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void SumOfExpense_02_CheckIfListIsNull_ReturnsEqual()
        {
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SumOfExpense(nullList);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }
    }
}
