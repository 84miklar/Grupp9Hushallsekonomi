using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Grupp9Hushallsekonomi.Helpers;

namespace Grupp9Hushallsekonomi
{
    public class BudgetCalculator
    {
        public static List<IAccount> listOfEconomy = new List<IAccount>();
        Outcome outcome = new Outcome();
        Income income = new Income();
        Logger log = new Logger();
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
        /// Metod där varje utgift jämförs med kvarvarande inkomst innan den dras av.
        /// True = utgift dras av och loggas till budgetrapport.
        /// False = Oavdragen utgift loggas till budgetrapport och felmeddelande.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public void WithdrawEachOutcome(List<IAccount> listOfEconomy)
        {
            if(listOfEconomy != null)
            {
                foreach (Outcome bill in listOfEconomy)
                {
                    if (bill.Money <= income.Money)
                    {
                        income.Money -= bill.Money;
                        //TODO: Logga bill.Name och bill.Money i budgetrapport.
                        log.BudgetLog();
                    }
                    else
                    {
                        //TODO: Logga i felmeddelanden och i budgetrapporten att summa inte dragits.
                        log.ErrorLog();
                        log.BudgetLog();
                    }
                }
            }
        }

        /// <summary>
        /// Metod som returnerar pengar man har kvar på kontot genom att beräkna inkomsterna minus utgifterna
        /// </summary>
        /// <returns>pengar kvar på kontot</returns>
        public double Withdraw()
        {
            return income.Money - outcome.Money;
        }

        /// <summary>
        /// Metod som räknar ihop summan av alla inkomster
        /// </summary>
        /// <returns>summan av alla inkomster</returns>
        public double SumOfIncome()
        {
            return listOfEconomy.Where(n => n != null).Where(x => x is Income).Sum(m => m.Money);
        }
        /// <summary>
        /// Metod som räknar ihop summan av alla utgifter
        /// </summary>
        /// <returns>summan av alla utgifter</returns>
        public double SumOfOutcome()
        {
            return listOfEconomy.Where(n => n != null).Where(x => x is Outcome).Sum(m => m.Money);
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
