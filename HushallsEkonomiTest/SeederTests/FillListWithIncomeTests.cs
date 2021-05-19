using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.SeederTests
{
    public class FillListWithIncomeTests
    {
        [Test]
        public void FillListWithIncome_01_CheckIfIncomeExistsInList_ReturnsTrue()
        {
            
            Seeder seeder = new Seeder();
            seeder.FillListWithIncome();
            var income = BudgetCalculator.listOfEconomy.FirstOrDefault(x => x is Income);
            var actual = income is Income;
            Assert.IsTrue(actual);
        }
    }
}
