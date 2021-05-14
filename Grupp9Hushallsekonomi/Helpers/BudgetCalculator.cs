﻿using Grupp9Hushallsekonomi.Account;
using Grupp9Hushallsekonomi.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Grupp9Hushallsekonomi.Helpers;
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace Grupp9Hushallsekonomi
{
    public class BudgetCalculator
    {
        public static List<IAccount> listOfEconomy = new List<IAccount>();
        public static List<Savings> savings = new List<Savings>();
        public Outcome totalOutcome = new Outcome();
        public Income totalIncome = new Income();
        Logger log = new Logger();
        public List<string> errorMessages = new List<string>();
        public List<string> boughtItems = new List<string>();
        /// <summary>
        /// Metod som separerar Income och Outcome från en lista av IAccount.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public List<IAccount> SeparateIncomeAndOutcome(List<IAccount> listOfEconomy)
        {
            if (listOfEconomy != null)
            {
                foreach (var item in listOfEconomy)
                {
                    if (item is Outcome)
                    {
                        totalOutcome.Money += item.Money;
                    }
                    if (item is Income)
                    {
                        totalIncome.Money += item.Money;
                    }
                }
                return listOfEconomy;
            }
            return null;
        }

        /// <summary>
        /// Metod där varje utgift jämförs med kvarvarande inkomst innan den dras av.
        /// True = Utgift dras av och loggas till budgetrapport.
        /// False = Oavdragen utgift loggas till budgetrapport och felmeddelande.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public double WithdrawEachOutcome(List<IAccount> listOfEconomy)
        {
            if (listOfEconomy != null)
            {
                foreach (var bill in listOfEconomy)
                {
                    if (bill is Outcome && bill.Money <= totalIncome.Money)
                    {
                        totalIncome.Money -= bill.Money;
                        //TODO: Logga bill.Name och bill.Money i budgetrapport.
                        boughtItems.Add(bill.Name);
                        boughtItems.Add(bill.Money.ToString());
                        log.BudgetLog(boughtItems);
                        boughtItems.Clear();
                    }
                    else if (bill is Outcome && bill.Money > totalIncome.Money)
                    {
                        //TODO: Logga i felmeddelanden och i budgetrapporten att summa inte dragits.
                        errorMessages.Add($"Not enough money on account to buy {bill.Name}");
                        boughtItems.Add($"{bill.Name} {bill.Money} not successfull transaction!");
                        log.ErrorLog(errorMessages);
                        log.BudgetLog(boughtItems);
                        errorMessages.Clear();
                    }
                }
                return totalIncome.Money;
            }
            return totalIncome.Money;
        }

        /// <summary>
        /// Metod som returnerar pengar man har kvar på kontot genom att beräkna inkomsterna minus utgifterna
        /// </summary>
        /// <returns>pengar kvar på kontot</returns>
        public double Withdraw()
        {
            return totalIncome.Money - totalOutcome.Money;
        }

        /// <summary>
        /// Metod som räknar ihop summan av alla inkomster
        /// </summary>
        /// <returns>summan av alla inkomster</returns>
        public double SumOfIncome()
        {
            //var query = (from x 
            //             in listOfEconomy 
            //             where x is Income 
            //             && x != null 
            //             select x.Money ).Sum();

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
        //public double Savings(double moneyLeft)
        //{
        //    double savingsProcentage = 0.1;
        //    if (moneyLeft > 0)
        //    {
        //        double savings = moneyLeft * savingsProcentage;
        //        listOfEconomy.Add(new Outcome { Money = savings, Name = "Savings" });
        //    }
        //    return moneyLeft;
        //}
        public bool Savings()
        {

            var moneyLeft = Withdraw();
            if (moneyLeft > 0)
            {

                foreach (var saving in savings)
                {
                    var result = moneyLeft * saving.SavingsPercantage;

                    if (moneyLeft > result)
                    {
                        moneyLeft -= result;
                    }
                }
                return true;
            }
            return false;

        }
    }
}
