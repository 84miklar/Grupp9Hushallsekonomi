using Grupp9Hushallsekonomi;
using NUnit.Framework;

namespace HushallsEkonomiTest
{
    public class Tests
    {
        [Test]
        public void CheckIncome_NegativeResult_01()
        {
            var income = new Income();
            var actual = income.Salary = 0;
            var expected = 0;

            Assert.AreEqual(actual, expected);
        }
    }
}