using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Helpers;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace HushallsEkonomiTest
{
    public class Tests
    {
        BudgetCalculator bc = new BudgetCalculator();
        [SetUp]
        public void SetUp()
        {
            Seeder seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithOutcome();
            bc.SeparateIncomeAndOutcome(BudgetCalculator.listOfEconomy);

        }
        [Test]
        public void SumOfIncome_01_ChecksIfIncomeIsLessOrEqualToZero_ReturnFalse()
        {
            var income = bc.SumOfIncome();
            var actual = income <= 0;


            Assert.IsFalse(actual);
        }
        [Test]
        public void SumOfIncome_02_ChecksIfIncomeIsBiggerThanZero_ReturnTrue()
        {
            BudgetCalculator.listOfEconomy.Add( new Income() { Money = double.MaxValue + 1, Name = "test" });
            Assert.IsTrue(bc.SumOfIncome() > 0);
        }
        [Test]
        public void SeparateIncomeAndOutcome_01_CheckIfListIsNull_ReturnNull()
        {
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var result = bc.SeparateIncomeAndOutcome(nullList);
            Assert.IsNull(result);

        }
       


        [Test]
        public void WithdrawEachOutcome_01_CheckIf()
        {
            var expected = bc.Withdraw();
            var actual = bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawEachOutcome_02_CheckIfListIsNull_ReturnNotEqual()
        {
            var expected = bc.Withdraw();
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.WithdrawEachOutcome(nullList);
            Assert.AreNotEqual(expected, actual);
        }

        [TestCase(double.MaxValue)]
        [Test]
        public void WithdrawEachOutcome_03_CheckOutcomeLargerThanIncome_ReturnEqual(double outcome)
        {
            var expected = bc.Withdraw();
            BudgetCalculator.listOfEconomy.Add(new Outcome() { Name = "VeryLargeBill", Money = outcome });
            var actual = bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void Savings_01_ChecksSuccessfullWithdraw_ReturnTrue()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            var actual = bc.Savings(BudgetCalculator.savings);
            Assert.IsTrue(actual);
        }
        [Test]
        public void Savings_02_ChecksUnsuccessfullWithdraw_ReturnFalse()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            bc.totalIncome.Money = 0;
            var actual = bc.Savings(BudgetCalculator.savings);
            Assert.IsFalse(actual);
        }
        [Test]
        public void Savings_03_ChecksIfPrecentageIsOverMaxPercentage_ReturnEqual()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            BudgetCalculator.savings.Add(new Savings("Error", 1.1));
            var actual = bc.Savings(BudgetCalculator.savings);
            var expected = bc.totalIncome.Money >= 0;
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void Savings_04_ChecksIfListIsNull_ReturnFalse()
        {
            List<Savings> nullList = new List<Savings>();
            nullList = null;
            var actual = bc.Savings(nullList);
            Assert.IsFalse(actual);
        }
        [Test]
        [TestCase(1000, 500)]
        [TestCase(0,0)]
        public void CalculatePercentageToMoney_01_CheckPercentageValue_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }

        [TearDown]
        public void Clear()
        {
            BudgetCalculator.listOfEconomy.Clear();
            bc.totalIncome.Money = 0;
            bc.totalOutcome.Money = 0;
        }

    }
}