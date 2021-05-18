using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest
{
    public class SeparateIncomeAndExpenseTests
    {
        BudgetCalculator bc = new BudgetCalculator();
        [Test]
        public void SeparateIncomeAndExpense_01_CheckIfListIsNull_ReturnNull()
        {
            List<IAccount> nullList = new List<IAccount>();
            nullList = null;
            var result = bc.SeparateIncomeAndExpense(nullList);
            Assert.IsNull(result);

        }
    }
}
