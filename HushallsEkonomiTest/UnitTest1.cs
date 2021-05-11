using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;

namespace HushallsEkonomiTest
{
    public class Tests
    {
        BudgetCalculator bc = new BudgetCalculator();
        [SetUp]
        public void SetUp()
        {
            bc.FillListWithIncome();
            bc.FillListWithOutcome();

        }
        [Test]
        public void CheckIncome_NegativeResult_01()
        {
            var income = bc.FillListWithIncome();
            var actual = income <= 0;


            Assert.IsFalse(actual);
        }
    }
}