using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Grupp9Hushallsekonomi
{
    public class BudgetCalculator
    {
        public List<IAccount> listOfEconomy = new List<IAccount>();
        Outcome outcome = new Outcome();
        Income income = new Income();
        /// <summary>
        /// Metod som separerar Income och Outcome från en lista av IAccount.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public void SeparateIncomeAndOutcome(List<IAccount> listOfEconomy)
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
        /// <summary>
        /// Metod som returnerar pengar man har kvar på kontot genom att beräkna inkomsterna minus utgifterna
        /// </summary>
        /// <returns></returns>
        public double Withdraw()
        {
            return income.Money - outcome.Money;
        }
        /// <summary>
        /// Metod som lägger till inkomst till IAccountlistan listOfEconomy
        /// </summary>
        /// <returns></returns>
        public double FillListWithIncome()
        {
            listOfEconomy.Add(new Income { Money = 14500, Name = "Salary" });
            return listOfEconomy.Where(n=>n!=null).Where(x => x is Income).Sum(m => m.Money);
            
            //double totalIncome = 0;
            //foreach (var income in listOfEconomy)
            //{
            //    totalIncome += income.Money;
            //}
            //return totalIncome;
        }
        /// <summary>
        /// Metod som lägger till utgifter till IAccountlistan lListOfEconomy
        /// </summary>
        /// <returns></returns>
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
            return listOfEconomy.Where(n => n !=null).Where(x => x is Outcome).Sum(m => m.Money);
            //double totalOutcome = 0;
            //foreach (var outcome in listOfEconomy)
            //{
            //    totalOutcome += outcome.Money;
            //}
            //return totalOutcome;
        }
        /// <summary>
        /// Metod som räknar ut och lägger till 10% av pengarna på kontot som sparande.
        /// </summary>
        /// <param name="moneyLeft"></param>
        /// <returns></returns>
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
