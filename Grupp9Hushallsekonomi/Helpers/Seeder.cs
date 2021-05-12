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
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 8900, Name = "Rent" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 2000, Name = "Food" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 89, Name = "Netflix" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 99, Name = "Phone" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 199, Name = "Broadband" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 600, Name = "Consumables" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 45, Name = "Bank Fee" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 1000, Name = "Pension" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 350, Name = "Gym" });
            BudgetCalculator.listOfEconomy.Add(new Outcome { Money = 75, Name = "Home Insurance" });
        }
    }
}
