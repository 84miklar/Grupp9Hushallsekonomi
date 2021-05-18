using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp9Hushallsekonomi.Helpers
{
    public class Logger
    {
        public List<string> boughtItems = new List<string>();
        public List<string> errorMessages = new List<string>();
        public void ErrorLog(List<string> errorMessages)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var errorLog = Path.Combine(desktop, "ErrorMessages.log");
            File.AppendAllText(errorLog, DateTime.Now + ":\r");
            File.AppendAllLines(errorLog, errorMessages);
            File.AppendAllText(errorLog, "\n");
            Debug.WriteLine(errorLog);
        }
        public void BudgetLog(List<string> boughtItems)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var budgetLog = Path.Combine(desktop, "BudgetLog.log");
            File.AppendAllText(budgetLog, DateTime.Now + ":\r");
            File.AppendAllLines(budgetLog, boughtItems);
            File.AppendAllText(budgetLog, "\n");
        }

        /// <summary>
        /// Method for sending boughtItems list to logger.
        /// </summary>
        public void AddBoughtItemsListToLogger()
        {
            BudgetLog(boughtItems);
        }

        /// <summary>
        /// Method for sending boughtItems list to logger.
        /// </summary>
        public void AddErrorMessagesListToLogger()
        {
            ErrorLog(errorMessages);
        }


        /// <summary>
        /// Method for adding a string to the boughtItems list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="textToLog"></param>
        public void AddStringToBoughtItemsList(string textToLog)
        {
            boughtItems.Add(textToLog);
        }

        /// <summary>
        /// Method for adding a string to the errorMessages list,
        /// like bill.Name and bill.Money.ToString()"
        /// </summary>
        /// <param name="textToLog"></param>
        public void AddStringToErrorMessagesList(string textToLog)
        {
            errorMessages.Add(textToLog);
        }
    }
}
