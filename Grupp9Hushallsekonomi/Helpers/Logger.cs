namespace Grupp9Hushallsekonomi.Helpers
{
    using Grupp9Hushallsekonomi.Account;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Class that sends positive and negative messages to a file at your dekstop.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// List of expenses.
        /// </summary>
        public List<string> boughtItems = new List<string>();

        /// <summary>
        /// List of error messages.
        /// </summary>
        public List<string> errorMessages = new List<string>();

        /// <summary>
        /// Method for adding a string to the boughtItems list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemValue"></param>
        public void AddStringToBoughtItemsList(string itemName, string itemValue = "")
        {
            boughtItems.Add(itemName);
            boughtItems.Add(itemValue + " KR");
            boughtItems.Add($"Money left: {BudgetCalculator.totalIncome.Money}");
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
        /// Writes succesful withdraw to a file at your desktop.
        /// </summary>
        /// <param name="boughtItems"></param>
        public static void BudgetLog(List<string> boughtItems)
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
        public static void ErrorLog(List<string> errorMessages)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var errorLog = Path.Combine(desktop, "ErrorMessages.log");
            File.AppendAllText(errorLog, DateTime.Now + ":\r");
            File.AppendAllLines(errorLog, errorMessages);
            File.AppendAllText(errorLog, "\n");
            WriteToDebug(errorLog);
        }

        /// <summary>
        /// Sends errormessages to Debug.WriteLine.
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
