﻿using Grupp9Hushallsekonomi;
using Grupp9Hushallsekonomi.Helpers;
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
        private readonly BudgetCalculator bc = new BudgetCalculator();

        [SetUp]
        public void SetUp()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
            bc.SeparateIncomeAndExpense(BudgetCalculator.listOfEconomy);
        }
        [TearDown]
        public void Clear()
        {
            BudgetCalculator.listOfEconomy.Clear();
            BudgetCalculator.totalIncome.Money = 0;
            BudgetCalculator.totalExpense.Money = 0;
        }
        [Test]
        public void SeparateIncomeAndExpense_01_CheckIfListIsNull_ReturnNull()
        {
           var nullList = new List<IAccount>();
            nullList = null;
            var actual = bc.SeparateIncomeAndExpense(nullList);
            Assert.IsNull(actual);
        }
        [Test]
        public void SeparateIncomeAndExpense_02_CheckIfListIsEmpty_ReturnIsEmpty()
        {
           var emptyList = new List<IAccount>();
            var actual = bc.SeparateIncomeAndExpense(emptyList);
            Assert.IsEmpty(actual);
        }
    }
}
