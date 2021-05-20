namespace HushallsEkonomiTest.SeederTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    using System.Linq;
    public class FillListWithExpenseTests
    {
        [Test]
        public void FillListWithExpense_01_CheckIfExpenseExistsInList_ReturnsTrue()
        {
            var seeder = new Seeder();
            seeder.FillListWithExpenses();
            var expense = BudgetCalculator.listOfEconomy.Find(x => x is Expense);
            var actual = expense is Expense;
            Assert.IsTrue(actual);
        }
    }
}
