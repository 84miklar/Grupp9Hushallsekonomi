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
        Savings savings = new Savings();
        BudgetCalculator bc = new BudgetCalculator();
        [SetUp]
        public void SetUp()
        {
            Seeder seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithOutcome();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);

        }
        [Test]
        public void SumOfIncome_01_ChecksIfIncomeIsLessOrEqualToZero_ReturnFalse()
        {
            var income = bc.SumOfIncome(BudgetCalculator.listOfEconomy);
            var actual = income <= 0;


            Assert.IsFalse(actual);
        }
        [Test]
        public void SumOfIncome_02_ChecksIfIncomeIsBiggerThanZero_ReturnTrue()
        {
            BudgetCalculator.listOfEconomy.Add( new Income() { Money = double.MaxValue + 1, Name = "test" });
            Assert.IsTrue(bc.SumOfIncome(BudgetCalculator.listOfEconomy) > 0);
        }
        [Test]
        public void SeparateIncomeAndOutcome_01_CheckIfListIsNull_ReturnNull()
        {
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var result = bc.SeparateIncomeAndExpense(nullList);
            Assert.IsNull(result);

        }

       

        [Test]
        public void SumOfIncome_NegativeResult_01_02()
        {
            var actual = bc.SumOfIncome(BudgetCalculator.listOfEconomy);
            var expected = double.MaxValue;
            Assert.AreNotEqual(actual, expected);
        }


        [Test]
        public void SumOfIncome_NullCheck_01_01()
        {
            var income = BudgetCalculator.listOfEconomy.FirstOrDefault(x => x is Income);
            BudgetCalculator.listOfEconomy.Remove(income);
            var actual = bc.SumOfIncome(BudgetCalculator.listOfEconomy);
            var expected = 0;
            Assert.AreEqual(actual,expected);
        }
        
        [Test]
        public void SumOfIncome_NullCheck_01_02()
        {
            List <IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SumOfIncome(nullList);
            var expected = 0;
            Assert.AreEqual(actual, expected);
        }


        [Test]
        public void WithdrawEachOutcome_01_CheckIf()
        {
            var expected = bc.Withdraw();
            var actual = bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawEachOutcome_02_CheckIfListIsNull_ReturnNotEqual()
        {
            var expected = bc.Withdraw();
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.WithdrawEachExpense(nullList);
            Assert.AreNotEqual(expected, actual);
        }

        [TestCase(double.MaxValue)]
        [Test]
        public void WithdrawEachOutcome_03_CheckOutcomeLargerThanIncome_ReturnEqual(double outcome)
        {
            var expected = bc.Withdraw();
            BudgetCalculator.listOfEconomy.Add(new Expense() { Name = "VeryLargeBill", Money = outcome });
            var actual = bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void Savings_01_ChecksSuccessfullWithdraw_ReturnTrue()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            Assert.IsTrue(actual);
        }
        [Test]
        public void Savings_02_ChecksUnsuccessfullWithdraw_ReturnFalse()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.totalIncome.Money = 0;
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            Assert.IsFalse(actual);
        }
        [Test]
        public void Savings_03_ChecksIfPrecentageIsOverMaxPercentage_ReturnEqual()
        {
            Seeder seed = new Seeder();
            seed.FillListWithSavings();
            bc.WithdrawEachExpense(BudgetCalculator.listOfEconomy);
            BudgetCalculator.savings.Add(new Savings("Error", 1.1));
            var actual = savings.CheckSavings(BudgetCalculator.savings);
            var expected = BudgetCalculator.totalIncome.Money >= 0;
            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void Savings_04_ChecksIfListIsNull_ReturnFalse()
        {
            List<Savings> nullList = new List<Savings>();
            nullList = null;
            var actual = savings.CheckSavings(nullList);
            Assert.IsFalse(actual);
        }
        [Test]
        [TestCase(1000, 500)]
        [TestCase(500,250)]
        [TestCase(100,50)]
        public void CalculatePercentageToMoney_01_CheckPercentageValuePositiveInput_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        [TestCase(-546049, 0)]
        [TestCase(0, 0)]
        [TestCase(-10, 0)]
        public void CalculatePercentageToMoney_02_CheckPercentageValueNegativeInput_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.CalculatePercentageToMoney(income);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        [TestCase(1000, 500)]
        [TestCase(500, 250)]
        [TestCase(100, 50)]
        public void SumLeftAfterSaving_01_CheckSumLeftPositiveInput_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.SumLeftAfterSaving(income);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        [TestCase(-54, 0)]
        [TestCase(-10, 0)]
        [TestCase(0, 0)]
        public void SumLeftAfterSaving_02_CheckSumLeftNegativeInput_ReturnEqual(double income, double expected)
        {
            Savings savings = new Savings("test", 0.5);
            var actual = savings.SumLeftAfterSaving(income);
            Assert.AreEqual(actual, expected);
        }
        [Test]
        [TestCase(1000)]
        [TestCase(500)]
        [TestCase(200)]
        public void IsSavingPossible_01_CheckWithPositiveInput_ReturnTrue(double income)
        {
            var saving = new Savings("test", 0.5);
            var actual = saving.IsSavingPossible(income);
            Assert.IsTrue(actual);
        }
        [Test]
        [TestCase(-5)]
        [TestCase(-40)]
        [TestCase(0)]
        public void IsSavingPossible_02_CheckWithNegativeInput_ReturnFalse(double income)
        {
            var saving = new Savings("test", 0.5);
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