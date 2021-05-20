namespace HushallsEkonomiTest.SeederTests
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    using System.Linq;
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
    }
}
