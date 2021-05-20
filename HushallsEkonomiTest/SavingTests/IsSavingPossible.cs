namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    public class IsSavingPossible
    {
        private readonly BudgetCalculator bc = new BudgetCalculator();
        [SetUp]
        public void SetUp()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);
        }

        [Test]
        [TestCase(1000)]
        [TestCase(500)]
        [TestCase(200)]
        public void IsSavingPossible_01_CheckWithPositiveInput_ReturnTrue(double income)
        {
            var saving = new Saving("test", 0.5);
            var actual = saving.IsSavingPossible(income);
            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(-5)]
        [TestCase(-40)]
        [TestCase(0)]
        public void IsSavingPossible_02_CheckWithNegativeInput_ReturnFalse(double income)
        {
            var saving = new Saving("test", 0.5);
            var actual = saving.IsSavingPossible(income);
            Assert.IsFalse(actual);
        }

        [TearDown]
        public void Clear()
        {
            BudgetCalculator.listOfEconomy.Clear();
            BudgetCalculator.totalIncome.Money = 0;
            BudgetCalculator.totalExpense.Money = 0;
        }
    }
}
