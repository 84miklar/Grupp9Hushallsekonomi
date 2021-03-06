namespace HushallsEkonomiTest.SeederTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

    public class FillListWithIncomeTests
    {
        [Test]
        public void FillListWithIncome_01_CheckIfIncomeExistsInList_ReturnsTrue()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            var income = BudgetCalculator.listOfEconomy.Find(x => x is Income);
            var actual = income is Income;
            Assert.IsTrue(actual);
        }
        [Test]
        public void FillListWithIncome_02_CheckIfIncomePropertySetsValue_ReturnsEqual()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            BudgetCalculator.listOfEconomy.Add(new Income());
            var expected = BudgetCalculator.listOfEconomy.Find(x => x.Name == "Unknown");
            var actual = "Unknown";
            Assert.AreEqual(actual, expected.Name);
        }
    }
}