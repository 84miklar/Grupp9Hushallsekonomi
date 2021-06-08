namespace HushallsEkonomiTest.SeederTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

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

        [Test]
        public void FillListWithExpense_02_CheckIfExpensePropertySetsValue_ReturnsEqual()
        {
            var seeder = new Seeder();
            seeder.FillListWithExpenses();
            BudgetCalculator.listOfEconomy.Add(new Expense());
            var expense = BudgetCalculator.listOfEconomy.Find(x => x.Name == "Unknown");
            var actual = "Unknown";
            Assert.AreEqual(actual, expense.Name);
        }
    }
}