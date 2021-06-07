namespace Grupp9Hushallsekonomi.Helpers
{
    using Grupp9Hushallsekonomi.Account;
    using Grupp9Hushallsekonomi.Interface;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Class that sends positive and negative messages to a file at your desktop.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// List of error messages.
        /// </summary>
        public readonly List<string> errorMessages = new List<string>();

        /// <summary>
        /// List of items to print to budget log.
        /// </summary>
        public readonly List<string> listToPrint = new List<string>();

        /// <summary>
        /// Holds the sum of Income left, to print to logger.
        /// </summary>
        public double totalMoney;
        /// <summary>
        /// Method for adding a string to the errorMessages list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="textToLog"></param>
        public void AddStringToErrorMessagesList(string textToLog)
        {
            errorMessages.Add(textToLog);
            errorMessages.Add("----------------------");
            AddErrorMessagesListToLogger();
        }

        /// <summary>
        /// Adds all items to listToPrint and sends to BudgetLog().
        /// </summary>
        public void LogAll()
        {
            if (listToPrint != null)
            {
                AddIncomeToList();
                AddExpensesToList();
                AddSavingsToList();

                listToPrint.Add("------------------");
                listToPrint.Add($"\nMoney left: {Math.Round(totalMoney, 2)}:-");
                BudgetLog(listToPrint);
            }
        }

        /// <summary>
        /// Writes successful withdraw to a file at your desktop.
        /// </summary>
        /// <param name="boughtItems"></param>
        private static void BudgetLog(List<string> boughtItems)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var budgetLog = Path.Combine(desktop, "BudgetLog.log");
            File.AppendAllText(budgetLog, DateTime.Now + ":\r");
            File.AppendAllLines(budgetLog, boughtItems);
            File.AppendAllText(budgetLog, "\n");
        }

        /// <summary>
        /// Writes error messages to a file at your desktop.
        /// </summary>
        /// <param name="errorMessages"></param>
        private static void ErrorLog(List<string> errorMessages)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var errorLog = Path.Combine(desktop, "ErrorMessages.log");
            File.AppendAllText(errorLog, DateTime.Now + ":\r");
            File.AppendAllLines(errorLog, errorMessages);
            File.AppendAllText(errorLog, "\n");
            WriteToDebug(errorLog);
        }

        /// <summary>
        /// Sends error messages to Debug.WriteLine.
        /// </summary>
        /// <param name="errorLog"></param>
        private static void WriteToDebug(string errorLog)
        {
            Debug.WriteLine(errorLog);
        }

        /// <summary>
        /// Method for sending boughtItems list to logger.
        /// </summary>
        private void AddErrorMessagesListToLogger()
        {
            ErrorLog(errorMessages);
        }

        /// <summary>
        /// Adds all expenses to listToPrint.
        /// </summary>
        private void AddExpensesToList()
        {
            listToPrint.Add("\nEXPENSES\n");
            if (BudgetCalculator.succesfulWithdrawns != null)
            {
                foreach (var item in BudgetCalculator.succesfulWithdrawns)
                {
                    totalMoney -= item.Money;
                    listToPrint.Add($"{item.Name}: {item?.Money}:-");
                }
            }
        }

        /// <summary>
        /// Adds all incomes to listToPrint.
        /// </summary>
        private void AddIncomeToList()
        {
            listToPrint.Add("\nINCOMES\n");
            var incomes = BudgetCalculator.listOfEconomy.Where(i => i is Income).ToList();
            if (incomes != null)
            {
                foreach (var item in incomes)
                {
                    totalMoney += item.Money;
                    listToPrint.Add($"{item.Name}: {item.Money}:-");
                }
            }
        }

        /// <summary>
        /// Adds all savings to listToPrint.
        /// </summary>
        private void AddSavingsToList()
        {
            var saving = new Saving();
            listToPrint.Add("\nSAVINGS\n");
            if (Saving.successfulSavingsWithdrawn != null)
            {
                foreach (var item in Saving.successfulSavingsWithdrawn)
                {
                    totalMoney = saving.CalculatePercentageToMoney(totalMoney, item.SavingsPercentage);
                    listToPrint.Add($"{item.Name}: {item.SavingsPercentage*100}%");
                }
            }
        }
    }
}