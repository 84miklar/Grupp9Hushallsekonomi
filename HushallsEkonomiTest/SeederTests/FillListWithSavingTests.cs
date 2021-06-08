namespace HushallsEkonomiTest.SeederTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

    public class FillListWithSavingTests
    {
        [Test]
        public void FillListWithIncome_01_CheckIfSavingExistsInList_ReturnsEqual()
        {
            var seeder = new Seeder();
            seeder.FillListWithSavings();
            var saving = BudgetCalculator.savingsList.Find(x => x is Saving);
            var actual = saving is Saving;
            Assert.IsTrue(actual);
        }
        [Test]
        public void FillListWithIncome_02_CheckIfSavingPropertySetsValue_ReturnsEqual()
        {
            var seeder = new Seeder();
            seeder.FillListWithSavings();
            BudgetCalculator.savingsList.Add(new Saving());
            var expected = BudgetCalculator.savingsList.Find(x => x.Name == "Unknown");
            var actual = "Unknown";
            Assert.AreEqual(actual, expected.Name);
        }
        [Test]
        public void FillListWithIncome_03_CheckIfSavingPropertySetsValue_ReturnsEqual()
        {
            var seeder = new Seeder();
            BudgetCalculator.savingsList.Add(null);
            var expected = BudgetCalculator.savingsList.Find(x => x.Name == "Unknown");
            var actual = "Unknown";
            Assert.AreEqual(actual, expected.Name);
        }
    }
}