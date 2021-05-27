namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

    public class SumLeftAfterSavingTests
    {
        private readonly Saving saving = new Saving { Name = "Test", SavingsPercentage = 0.5 };
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
        [TestCase(1000, 500)]
        public void SumLeftAfterSaving_01_CheckSumLeftPositiveInput_ReturnEqual(double incomeLeft, double expected)
        {
            var actual = saving.SumLeftAfterSaving(incomeLeft);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(-10, 0)]
        [TestCase(0, 0)]
        public void SumLeftAfterSaving_02_CheckSumLeftNegativeInput_ReturnEqual(double incomeLeft, double expected)
        {
            var actual = saving.SumLeftAfterSaving(incomeLeft);
            Assert.AreEqual(actual, expected);
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