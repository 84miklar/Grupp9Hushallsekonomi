using Grupp9Hushallsekonomi.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi.Helpers
{
    public class Seeder
    {
        /// <summary>
        /// Metod som lägger till inkomst till IAccountlistan listOfEconomy
        /// </summary>
        public void FillListWithIncome()
        {
            BudgetCalculator.listOfEconomy.Add(new Income { Money = 14500, Name = "Salary" });

        }
        /// <summary>
        /// Metod som lägger till utgifter till IAccountlistan lListOfEconomy
        /// </summary>
        public void FillListWithOutcome()
        {
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 8900, Name = "Rent" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 2000, Name = "Food" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 89, Name = "Netflix" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 99, Name = "Phone" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 199, Name = "Broadband" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 600, Name = "Consumables" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 45, Name = "Bank Fee" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 1000, Name = "Pension" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 350, Name = "Gym" });
            BudgetCalculator.listOfEconomy.Add(new Expense { Money = 75, Name = "Home Insurance" });
        }
        public void FillListWithSavings()
        {
            BudgetCalculator.savings.Add(new Saving("Car", 0.1));
            BudgetCalculator.savings.Add(new Saving("Boat",0.1));

        }
    }
}
