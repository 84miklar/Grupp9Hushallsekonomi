namespace HushallsEkonomiTest
{
    using Grupp9Hushallsekonomi;
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

    internal class CalculatePercentageToMoneyTests
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
        [TestCase(500.25, 250.12)]
        public void CalculatePercentageToMoney_01_CheckPercentageValuePositiveInput_ReturnEqual(double income, double expected)
        {
            var actual = saving.CalculatePercentageToMoney(income, saving.SavingsPercentage);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-10, 0)]
        public void CalculatePercentageToMoney_02_CheckPercentageValueNegativeInput_ReturnEqual(double income, double expected)
        {
            var actual = saving.CalculatePercentageToMoney(income, saving.SavingsPercentage);
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