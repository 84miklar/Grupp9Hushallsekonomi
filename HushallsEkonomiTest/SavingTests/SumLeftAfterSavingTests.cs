namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    public class SumLeftAfterSavingTests
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
        [TestCase(1000, 500)]
        [TestCase(500, 250)]
        [TestCase(100, 50)]
        public void SumLeftAfterSaving_01_CheckSumLeftPositiveInput_ReturnEqual(double income, double expected)
        {
            var savings = new Saving("test", 0.5);
            var actual = savings.SumLeftAfterSaving(income);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(-54, 0)]
        [TestCase(-10, 0)]
        [TestCase(0, 0)]
        public void SumLeftAfterSaving_02_CheckSumLeftNegativeInput_ReturnEqual(double income, double expected)
        {
            var savings = new Saving("test", 0.5);
            var actual = savings.SumLeftAfterSaving(income);
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
