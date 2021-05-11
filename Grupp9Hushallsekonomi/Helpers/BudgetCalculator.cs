using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi
{
    public class BudgetCalculator
    {
        List<IAccount> listOfEconomy = new List<IAccount>();
        Outcome outcome = new Outcome();
        Income income = new Income();
        public void SeparateIncomeAndOutcome(List<IAccount>listOfEconomy)
        {
            foreach (var item in listOfEconomy)
            {
                if (item is Outcome)
                {
                    outcome.Money += item.Money;
                }
                if (item is Income)
                {
                    income.Money += item.Money;
                }
            }
        }
        public double Withdraw()
        {
            return income.Money - outcome.Money;
        }
        public void FillListWithIncome()
        {
            listOfEconomy.Add(new Income { Money = 14500 });
        }
        public void FillListWithOutcome()
        {
            listOfEconomy.Add(new Outcome { Money = 14500 });
        }
    }
}
