using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.SeederTests
{
    public class FillListWithSavingTests
    {

        [Test]
        public void FillListWithIncome_01_CheckIfIncomeExistsInList_ReturnsEqual()
        {
            Seeder seeder = new Seeder();
            seeder.FillListWithSavings();
            var saving = BudgetCalculator.savings.FirstOrDefault(x => x is Saving);
            var actual = saving is Saving;
            Assert.IsTrue(actual);
        }
    }
}
