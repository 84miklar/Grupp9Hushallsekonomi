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
        /// List of expenses.
        /// </summary>
        public readonly List<string> boughtItems = new List<string>();
        public readonly List<string> listToPrint = new List<string>();
        /// <summary>
        /// List of error messages.
        /// </summary>
        public readonly List<string> errorMessages = new List<string>();

        public void LogAll()
        {
            listToPrint.Add("\nINCOMES\n");
            var incomes = BudgetCalculator.listOfEconomy.Where(i => i is Income).ToList();
            foreach(var item in incomes)
            {
                listToPrint.Add($"{item.Name}: {item.Money}:-");
            }
            listToPrint.Add("\nEXPENSES\n");
            var expenses = BudgetCalculator.listOfEconomy.Where(e => e is Expense).ToList();
            foreach (var item in expenses)
            {
                listToPrint.Add($"{item.Name}: {item.Money}:-");
            }
            listToPrint.Add("\nSAVINGS\n");
            foreach (var item in BudgetCalculator.savingsList)
            {
                listToPrint.Add($"{item.Name}: {item.SavingsPercentage*100}%");
            }
            listToPrint.Add("------------------");
            listToPrint.Add($"\nMoney left: {Math.Round(BudgetCalculator.totalIncome.Money, 2)}:-");
            BudgetLog(listToPrint);
        }

        /// <summary>
        /// Method for adding a string to the boughtItems list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemValue"></param>
        public void AddStringToBoughtItemsList(string itemName, string itemValue = "")
        {
            boughtItems.Add($"{itemName}: {itemValue} KR");
            boughtItems.Add($"Money left: {Math.Round(BudgetCalculator.totalIncome.Money, 2)} KR");
            boughtItems.Add("----------------------");
            AddBoughtItemsListToLogger();
        }

        public void AddStringToBoughtItemsList(string itemName, string itemValue = "", string totalSaving = "")
        {
            boughtItems.Add($"Saving: {itemName}: {itemValue} KR");
            boughtItems.Add($"Total savings: {totalSaving} KR");
            boughtItems.Add($"Money left: {Math.Round(BudgetCalculator.totalIncome.Money, 2)} KR");
            boughtItems.Add("----------------------");
            AddBoughtItemsListToLogger();
        }

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
        private void AddBoughtItemsListToLogger()
        {
            BudgetLog(boughtItems);
        }

        /// <summary>
        /// Method for sending boughtItems list to logger.
        /// </summary>
        private void AddErrorMessagesListToLogger()
        {
            ErrorLog(errorMessages);
        }
    }
}