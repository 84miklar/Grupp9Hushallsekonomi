using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Helpers;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
        public void SumOfIncome_NegativeResult_01_01()
        {
            var income = bc.SumOfIncome();
            var actual = income <= 0;


            Assert.IsFalse(actual);
        }
        [Test]
        public void SeparateIncomeAndOutcome_NegativeResult_01_02()
        {
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var result = bc.SeparateIncomeAndOutcome(nullList);
            Assert.IsNull(result);
           
        }
        [Test]
        public void SumOfIncome_NegativeResult_01_02()
        {
            var actual = bc.SumOfIncome();
            var expected = double.MaxValue;
            Assert.AreNotEqual(actual, expected);
        }


        [Test]
        public void WithdrawEachOutcome_PositiveResult_01()
        {
            var expected = bc.Withdraw();
            var actual = bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void WithdrawEachOutcome_NegativeResult_01()
        {
            var expected = bc.Withdraw();
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.WithdrawEachOutcome(nullList);
            Assert.AreNotEqual(expected, actual);
        }

    }
}