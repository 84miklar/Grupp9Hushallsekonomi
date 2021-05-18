namespace Grupp9Hushallsekonomi
{
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Grupp9Hushallsekonomi.Helpers;

    /// <summary>
    /// Calculator for handling Income and expenses
    /// </summary>
    public class BudgetCalculator
    {
        public static List<IAccount> listOfEconomy = new List<IAccount>();
        public static List<Savings> savings = new List<Savings>();
        public static Income totalIncome = new Income();
        public static Expense totalExpense = new Expense();
        Logger log = new Logger();
       
        /// <summary>
        /// Metod som separerar Income och Outcome från en lista av IAccount.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public List<IAccount> SeparateIncomeAndExpense(List<IAccount> listOfEconomy)
        {
            if (listOfEconomy != null)
            {
                foreach (var item in listOfEconomy)
                {
                    if (item is Expense)
                    {
                        totalExpense.Money += item.Money;
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
            try
            {
                return listToSum.Where(x => x is Income).Where(i => i.Money > 0).Sum(m => m.Money);
            }
            catch (Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.ToString());
                log.AddErrorMessagesListToLogger();
                return 0;
            }
        }

        /// <summary>
        /// Metod som räknar ihop summan av alla utgifter
        /// </summary>
        /// <returns>summan av alla utgifter</returns>
        public double SumOfExpense(List<IAccount> listToSum)
        {
            try
            {
                return listToSum.Where(x => x is Expense).Sum(m => m.Money);
            }
            catch (Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.ToString());
                log.AddErrorMessagesListToLogger();
                return 0;
            }
        }

        /// <summary>
        /// Metod som returnerar pengar man har kvar på kontot genom att beräkna inkomsterna minus utgifterna
        /// </summary>
        /// <returns>pengar kvar på kontot</returns>
        public double Withdraw()
        {
            return totalIncome.Money - totalExpense.Money;
        }

        /// <summary>
        /// Method where every outcome compares to if there is sufficiant income left, before it is deducted.
        /// True = Outcome is deducted and logged to budget rapport.
        /// False = Undeducted outcome is logged to budget rapport and error messages.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public double WithdrawEachExpense(List<IAccount> listOfEconomy)
        {
            if (listOfEconomy != null)
            {
                CheckIfExpenseWithdrawIsPossible(listOfEconomy);
                return totalIncome.Money;
            }
            return totalIncome.Money;
        }

        /// <summary>
        /// Sets if expense withdraw is possible or not.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        private void CheckIfExpenseWithdrawIsPossible(List<IAccount> listOfEconomy)
        {
            foreach (var bill in listOfEconomy)
            {
                if (bill is Expense && bill.Money <= totalIncome.Money)
                {
                    SuccessfulReduceIncomeWithExpense(bill);
                }
                else if (bill is Expense && bill.Money > totalIncome.Money)
                {
                    UnsuccessfullReduceIncomeWithExpense(bill);
                }
            }
        }

        /// <summary>
        /// Method for reducing the income with an outcome.
        /// </summary>
        /// <param name="bill"></param>
        private void SuccessfulReduceIncomeWithExpense(IAccount bill)
        {
            totalIncome.Money -= bill.Money;
            log.AddStringToBoughtItemsList(bill.Name);
            log.AddStringToBoughtItemsList(bill.Money.ToString());
            log.AddBoughtItemsListToLogger();
            log.boughtItems.Clear();
        }

        /// <summary>
        /// Method that calls when there is insufficient income to withdraw an outcome.
        /// </summary>
        /// <param name="bill"></param>
        private void UnsuccessfullReduceIncomeWithExpense(IAccount bill)
        {
            log.AddStringToErrorMessagesList($"Not enough money on account to buy {bill.Name}");
            log.AddStringToBoughtItemsList($"{bill.Name} {bill.Money} not successfull transaction!");
            log.AddErrorMessagesListToLogger();
            log.AddBoughtItemsListToLogger();
            log.errorMessages.Clear();
        }
    }
}
