namespace Grupp9Hushallsekonomi.Account
{
    using Helpers;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class to handle all the savings.
    /// </summary>
    public class Saving
    {
        /// <summary>
        /// Savings maximum value possible.
        /// </summary>
        public const double MaxPercentage = 1.0;

        /// <summary>
        /// The name of the saving.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The savings percentage to set.
        /// </summary>
        public double SavingsPercentage { get; set; }

        public static readonly List<Saving> successfulSavingsWithdrawn = new List<Saving>();
        /// <summary>
        /// Checks If saving withdraw is possible
        /// </summary>
        /// <param name="savingsList"></param>
        /// <returns>True if savings is withdrawn
        /// False if list is null</returns>
        public static bool CheckSavings(List<Saving> savingsList)
        {
            double totalSavings = 0;
            var log = new Logger();

            try
            {
                return CheckIfSavingListIsNullOrEmpty(savingsList) && BudgetCalculator.totalIncome.Money > 0 &&
                CheckifSavingIsPossibleAndLog(savingsList, ref totalSavings, log);
            }
            catch (System.Exception ex)
            {
                log.AddStringToErrorMessagesList(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Turns the percentage value of a saving into money value.
        /// </summary>
        /// <param name="income"></param>
        /// <param name="savingsPercentage"></param>
        /// <returns>The value of a saving in double</returns>
        public double CalculatePercentageToMoney(double income, double savingsPercentage)
        {
            var actualPercentage = MaxPercentage - savingsPercentage;
            return Math.Round(income > 0 ? income * actualPercentage : 0, 2);
        }
        /// <summary>
        /// Checks if income is more than zero and saving is possible.
        /// </summary>
        /// <param name="income"></param>
        /// <returns>True if possible</returns>
        public bool IsSavingPossible(double income)
        {
            return income > 0 && CheckSumAfterSavingAndSavingsPercentage(income);
        }

        /// <summary>
        /// Reduces the saving from the income.
        /// </summary>
        /// <param name="income"></param>
        /// <returns>Income - saving in double.</returns>
        public double SumLeftAfterSaving(double income)
        {
            return income > 0 ? income - CalculatePercentageToMoney(income, SavingsPercentage) : 0;
        }

        /// <summary>
        /// Checks if a saving is possible to withdraw, and logs it.
        /// </summary>
        /// <param name="savingsList"></param>
        /// <param name="totalSavings"></param>
        /// <param name="log"></param>
        /// <returns>true if saving is withdrawn from expenses.</returns>
        private static bool CheckifSavingIsPossibleAndLog(List<Saving> savingsList, ref double totalSavings, Logger log)
        {
            foreach (var saving in savingsList)
            {
                if (saving.IsSavingPossible(BudgetCalculator.totalIncome.Money))
                {
                    SavingIsPossible(ref totalSavings, saving);
                }
                SavingIsNotPossible(log, saving);
            }
            return true;
        }

        /// <summary>
        /// Checks if a list is empty or null.
        /// </summary>
        /// <param name="savingsList"></param>
        /// <returns>True if list is not null or empty.</returns>
        private static bool CheckIfSavingListIsNullOrEmpty(List<Saving> savingsList)
        {
            return savingsList?.Count > 0;
        }
        /// <summary>
        /// Saving is not possible due to lack of income.
        /// Logs as an error.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="saving"></param>
        private static void SavingIsNotPossible(Logger log, Saving saving)
        {
            log.AddStringToErrorMessagesList($"Not enough money for {saving.Name}");
            log.errorMessages.Clear();
        }

        /// <summary>
        /// Saving is possible due to enough money left.
        /// MoneyLeft is reduced.
        /// TotalSavings is increased.
        /// Saving is logged to desktop file.
        /// </summary>
        /// <param name="totalSavings"></param>
        /// <param name="saving"></param>
        private static void SavingIsPossible(ref double totalSavings, Saving saving)
        {
            BudgetCalculator.totalIncome.Money -= saving.SumLeftAfterSaving(BudgetCalculator.totalIncome.Money);
            totalSavings += saving.CalculatePercentageToMoney(BudgetCalculator.totalIncome.Money, saving.SavingsPercentage);
            successfulSavingsWithdrawn.Add(saving);
        }

        /// <summary>
        /// Checks if a saving is possible to do.
        /// </summary>
        /// <param name="income"></param>
        /// <returns>True if sum of income left after saving is done is more than 0.</returns>
        private bool CheckSumAfterSavingAndSavingsPercentage(double income)
        {
            var sumAfterSaving = SumLeftAfterSaving(income);
            return sumAfterSaving >= 0 && SavingsPercentage <= MaxPercentage;
        }
    }
}