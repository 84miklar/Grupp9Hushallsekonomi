namespace Grupp9Hushallsekonomi.Helpers
{
    using Grupp9Hushallsekonomi.Account;

    /// <summary>
    /// Class that adds objects to lists.
    /// </summary>
    public class Seeder
    {
        private readonly Logger logger = new Logger();

        /// <summary>
        /// Method that adds expenses to IAccount list listOfEconomy.
        /// </summary>
        public void FillListWithExpenses()
        {
            try
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
                BudgetCalculator.listOfEconomy.Add(new Expense { Money = -350, Name = "Gym Refund" });
            }
            catch (System.Exception ex)
            {
                logger.AddStringToErrorMessagesList(ex.Message);
            }
        }

        /// <summary>
        /// Method that adds income to IAccount list listOfEconomy.
        /// </summary>
        public void FillListWithIncome()
        {
            try
            {
                BudgetCalculator.listOfEconomy.Add(new Income { Money = 14500, Name = "Salary" });
            }
            catch (System.Exception ex)
            {
                logger.AddStringToErrorMessagesList(ex.Message);
            }
        }
        /// <summary>
        /// Method that adds savings to savingsList.
        /// </summary>
        public void FillListWithSavings()
        {
            try
            {
                BudgetCalculator.savingsList.Add(new Saving { SavingsPercentage = 0.1, Name = "Bicyckle" });
                BudgetCalculator.savingsList.Add(new Saving { SavingsPercentage = 0.1, Name = "Car" });
                BudgetCalculator.savingsList.Add(new Saving { SavingsPercentage = 0.1, Name = "Boat" });
            }
            catch (System.Exception ex)
            {
                logger.AddStringToErrorMessagesList(ex.Message);
            }
        }
    }
}