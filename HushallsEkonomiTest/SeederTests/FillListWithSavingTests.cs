namespace HushallsEkonomiTest.SeederTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

    public class FillListWithSavingTests
    {
        [Test]
        public void FillListWithIncome_01_CheckIfIncomeExistsInList_ReturnsEqual()
        {
            var seeder = new Seeder();
            seeder.FillListWithSavings();
            var saving = BudgetCalculator.savingsList.Find(x => x is Saving);
            var actual = saving is Saving;
            Assert.IsTrue(actual);
        }
    }
}