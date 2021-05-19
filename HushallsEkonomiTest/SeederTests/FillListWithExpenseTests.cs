using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.SeederTests
{
    public class FillListWithExpenseTests
    {
        
        [Test]
        public void FillListWithExpense_01_CheckIfExpenseExistsInList_ReturnsTrue()
        {
            
            Seeder seeder = new Seeder();
            seeder.FillListWithExpenses();
            var expense = BudgetCalculator.listOfEconomy.FirstOrDefault(x => x is Expense);
            var actual = expense is Expense;
            Assert.IsTrue(actual);
        }
    }
}
