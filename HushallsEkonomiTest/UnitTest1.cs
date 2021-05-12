using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Helpers;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
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

        }
        [Test]
        public void CheckIncome_NegativeResult_01()
        {
            var income = bc.SumOfIncome();
            var actual = income <= 0;


            Assert.IsFalse(actual);
        }
    }
}