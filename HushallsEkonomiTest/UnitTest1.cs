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
        public void CheckIncome_NegativeResult_01()
        {
            var income = bc.SumOfIncome();
            var actual = income <= 0;


            Assert.IsFalse(actual);
        }
        [Test]
        public void CheckIncome_NegativeResult_02()
        {
            BudgetCalculator.listOfEconomy = null;
            var result = bc.SeparateIncomeAndOutcome(BudgetCalculator.listOfEconomy);
            Assert.IsNull(result);
           
        }

        [Test]
        public void WithdrawEachOutcome_PositiveResult_01()
        {
            var expected = bc.Withdraw();
            var actual = bc.WithdrawEachOutcome(BudgetCalculator.listOfEconomy);
            Assert.AreEqual(expected, actual);
        }
    }
}