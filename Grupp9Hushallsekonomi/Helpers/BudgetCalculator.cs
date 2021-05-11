using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi
{
    public class BudgetCalculator
    {
        public List<IAccount> listOfEconomy = new List<IAccount>();
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
        public double FillListWithIncome()
        {
            double totalIncome = 0;
            listOfEconomy.Add(new Income { Money = 14500, Name = "Salary" });
            //listofEconomy(x => +x.Money).Sum();
            foreach (var income in listOfEconomy)
            {
                totalIncome += income.Money; 
            }
            return totalIncome;
        }
        public double FillListWithOutcome()
        {
            listOfEconomy.Add(new Outcome { Money = 8900, Name = "Rent" });
            listOfEconomy.Add(new Outcome { Money = 2000, Name = "Food" });
            listOfEconomy.Add(new Outcome { Money = 89, Name = "Netflix" });
            listOfEconomy.Add(new Outcome { Money = 99, Name = "Phone" });
            listOfEconomy.Add(new Outcome { Money = 199, Name = "Broadband" });
            listOfEconomy.Add(new Outcome { Money = 600, Name = "Consumables" });
            listOfEconomy.Add(new Outcome { Money = 45, Name = "Bank Fee" });
            listOfEconomy.Add(new Outcome { Money = 1000, Name = "Pension" });
            listOfEconomy.Add(new Outcome { Money = 350, Name = "Gym" });
            listOfEconomy.Add(new Outcome { Money = 75, Name = "Home Insurance" });
            double totalOutcome = 0;
            foreach (var outcome in listOfEconomy)
            {
                totalOutcome += outcome.Money;
            }
            return totalOutcome;
        }
        public double Savings(double moneyLeft)
        {
            double savingsProcentage = 0.1;
            if (moneyLeft > 0)
            {
                double savings = moneyLeft * savingsProcentage;
                listOfEconomy.Add(new Outcome { Money = savings, Name = "Savings" });
            }
            return moneyLeft;
        }
    }
}
