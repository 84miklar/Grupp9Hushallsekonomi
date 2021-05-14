using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp9Hushallsekonomi.Helpers
{
    public class Logger
    {
        public void ErrorLog(List<string> errorMessages)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var errorLog = Path.Combine(desktop, "ErrorMessages.log");
            File.AppendAllText(errorLog, DateTime.Now + ":\r");
            File.AppendAllLines(errorLog, errorMessages);
            File.AppendAllText(errorLog, "\n");
        }
        public void BudgetLog(List<string> boughtItems)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var budgetLog = Path.Combine(desktop, "ErrorMessages.log");
            File.AppendAllText(budgetLog, DateTime.Now + ":\r");
            File.AppendAllLines(budgetLog, boughtItems);
            File.AppendAllText(budgetLog, "\n");
        }
    }
}
