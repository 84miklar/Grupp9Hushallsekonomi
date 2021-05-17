using Grupp9Hushallsekonomi.Account;
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
    /// <summary>
    /// Calculator for handling Income and outcome
    /// </summary>
    public class BudgetCalculator
    {
        public static List<IAccount> listOfEconomy = new List<IAccount>();
        public static List<Savings> savings = new List<Savings>();
        public List<string> boughtItems = new List<string>();
        public List<string> errorMessages = new List<string>();
        public Income totalIncome = new Income();
        public Outcome totalOutcome = new Outcome();
        public double totalSavings = 0;
        Logger log = new Logger();
        /// <summary>
        /// Checks If saving withdraw is possible
        /// </summary>
        /// <param name="savingsList"></param>
        /// <returns>True if savings is withdrawn
        /// False if list is null</returns>
        public bool Savings(List<Savings> savingsList)
        {
            var moneyLeft = totalIncome.Money;
            if (moneyLeft > 0 && savingsList != null)
            {
                foreach (var saving in savingsList)
                {

                    if (saving.IsSavingPossible(moneyLeft))
                    {
                        moneyLeft -= saving.SumLeftAfterSaving(moneyLeft);
                        totalSavings += saving.CalculatePercentageToMoney(moneyLeft);
                        AddStringToBoughtItemsList(saving.Name);
                        AddStringToBoughtItemsList(saving.SumLeftAfterSaving(moneyLeft).ToString());
                        AddBoughtItemsListToLogger();
                    }
                    else
                    {
                        AddStringToErrorMessagesList($"Not enough money for {saving.Name}");
                        AddErrorMessagesListToLogger(); 
                    }
                }
                return true;
            }
            return false;
        }

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
        /// Metod som räknar ihop summan av alla inkomster
        /// </summary>
        /// <returns>summan av alla inkomster</returns>
        public double SumOfIncome(List<IAccount> listToSum)
        {
            //var query = (from x 
            //             in listOfEconomy 
            //             where x is Income 
            //             && x != null 
            //             select x.Money ).Sum();
            //
            try
            {
                return listToSum.Where(x => x is Income).Sum(m => m.Money);
            }
            catch (Exception ex)
            {
                AddStringToErrorMessagesList(ex.ToString());
                AddErrorMessagesListToLogger();
                return 0;
            }
        }

        /// <summary>
        /// Metod som räknar ihop summan av alla utgifter
        /// </summary>
        /// <returns>summan av alla utgifter</returns>
        public double SumOfOutcome(List<IAccount> listToSum)
        {
            try
            {
                return listToSum.Where(x => x is Outcome).Sum(m => m.Money);
            }
            catch (Exception ex)
            {
                AddStringToErrorMessagesList(ex.ToString());
                AddErrorMessagesListToLogger();
                return 0;
            }
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
        /// Method where every outcome compares to if there is sufficiant income left, before it is deducted.
        /// True = Outcome is deducted and logged to budget rapport.
        /// False = Undeducted outcome is logged to budget rapport and error messages.
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
                        SuccessfulReduceIncomeWithOutcome(bill);
                    }
                    else if (bill is Outcome && bill.Money > totalIncome.Money)
                    {
                        UnsuccessfullReduceIncomeWithOutcome(bill);
                    }
                }
                return totalIncome.Money;
            }
            return totalIncome.Money;
        }

        /// <summary>
        /// Method for sending boughtItems list to logger.
        /// </summary>
        private void AddBoughtItemsListToLogger()
        {
            log.BudgetLog(boughtItems);
        }

        /// <summary>
        /// Method for sending boughtItems list to logger.
        /// </summary>
        private void AddErrorMessagesListToLogger()
        {
            log.ErrorLog(errorMessages);
        }

        /// <summary>
        /// Method for adding a string to the boughtItems list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="textToLog"></param>
        private void AddStringToBoughtItemsList(string textToLog)
        {
            boughtItems.Add(textToLog);
        }

        /// <summary>
        /// Method for adding a string to the errorMessages list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="textToLog"></param>
        private void AddStringToErrorMessagesList(string textToLog)
        {
            errorMessages.Add(textToLog);
        }

        /// <summary>
        /// Method for reducing the income with an outcome.
        /// </summary>
        /// <param name="bill"></param>
        private void SuccessfulReduceIncomeWithOutcome(IAccount bill)
        {
            totalIncome.Money -= bill.Money;
            AddStringToBoughtItemsList(bill.Name);
            AddStringToBoughtItemsList(bill.Money.ToString());
            AddBoughtItemsListToLogger();
            boughtItems.Clear();
        }

        /// <summary>
        /// Method that calls when there is insufficient income to withdraw an outcome.
        /// </summary>
        /// <param name="bill"></param>
        private void UnsuccessfullReduceIncomeWithOutcome(IAccount bill)
        {
            AddStringToErrorMessagesList($"Not enough money on account to buy {bill.Name}");
            AddStringToBoughtItemsList($"{bill.Name} {bill.Money} not successfull transaction!");
            AddErrorMessagesListToLogger();
            AddBoughtItemsListToLogger();
            errorMessages.Clear();
        }
    }
}
