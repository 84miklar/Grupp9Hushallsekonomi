namespace Grupp9Hushallsekonomi
{
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Helpers;
    using Grupp9Hushallsekonomi.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Calculator for handling Income and expenses
    /// </summary>
    public class BudgetCalculator
    {
        /// <summary>
        /// List to store all successful withdraws, for use in Logger class.
        /// </summary>
        public static readonly List<IAccount> succesfulWithdrawns = new List<IAccount>();

        /// <summary>
        /// List that handles objects of IAccount, like Expense and Income.
        /// </summary>
        public static readonly List<IAccount> listOfEconomy = new List<IAccount>();

        /// <summary>
        /// List that handles objects of Saving.
        /// </summary>
        public static List<Saving> savingsList = new List<Saving>();

        /// <summary>
        /// Instance of Expense that holds the sum of all expenses.
        /// </summary>
        public static Expense totalExpense = new Expense();

        /// <summary>
        /// Instance of Income that holds the sum of all incomes.
        /// </summary>
        public static Income totalIncome = new Income();

        /// <summary>
        /// Instance of the Logger class to handle all messages to be logged.
        /// </summary>
        private readonly Logger log = new Logger();

        /// <summary>
        /// Method that separates Income and Expense from a list of IAccount.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public List<IAccount> SeparateIncomeAndExpense(List<IAccount> listOfEconomy)
        {
            try
            {
                if (listOfEconomy != null)
                {
                    foreach (var item in listOfEconomy)
                    {
                        if (item is Income)
                        {
                            totalIncome.Money += item.Money;
                        }
                        if (item is Expense)
                        {
                            totalExpense.Money += item.Money;
                        }
                    }
                    return listOfEconomy;
                }
            }
            catch (Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Method that calculates the sum of all Expenses
        /// </summary>
        /// <param name="listToSum"></param>
        /// <returns>sum of all Expenses</returns>
        public double SumOfExpense(List<IAccount> listToSum)
        {
            try
            {
                if (listToSum != null)
                {
                    return listToSum.Where(x => x is Expense).Sum(m => m.Money);
                }
            }
            catch (Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// Method that calculates the sum of all incomes.
        /// </summary>
        /// <param name="listToSum"></param>
        /// <returns>The sum of all incomes</returns>
        public double SumOfIncome(List<IAccount> listToSum)
        {
            try
            {
                if (listToSum != null)
                {
                    return listToSum.Where(x => x is Income).Where(i => i.Money > 0).Sum(m => m.Money);
                }
            }
            catch (Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// Method where every outcome compares to if there is sufficiant income left, before it is deducted.
        /// True = Outcome is deducted and logged to budget rapport.
        /// False = Undeducted outcome is logged to budget rapport and error messages.
        /// </summary>
        /// <param name="listOfEconomy"></param>
        public double WithdrawEachExpense(List<IAccount> listOfEconomy)
        {
            try
            {
                if (listOfEconomy != null || listOfEconomy.Count > 0)
                {
                    CheckIfExpenseWithdrawIsPossible(listOfEconomy);
                    return totalIncome.Money;
                }
            }
            catch (Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.Message);
            }
            return 0;
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
            succesfulWithdrawns.Add(bill);
        }

        /// <summary>
        /// Method that calls when there is insufficient income to withdraw an outcome.
        /// </summary>
        /// <param name="bill"></param>
        private void UnsuccessfullReduceIncomeWithExpense(IAccount bill)
        {
            log.AddStringToErrorMessagesList($"Not enough money on account to buy {bill?.Name ?? "Unknown"} {bill.Money}");
            log.errorMessages.Clear();
        }
    }
}