﻿namespace Grupp9Hushallsekonomi.Account
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

        public Saving(string name, double percantage)
        {
            Name = name;
            SavingsPercentage = percantage;
        }

        public Saving() { }

        /// <summary>
        /// The name of the saving.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The savings percentage to set.
        /// </summary>
        public double SavingsPercentage { get; set; }
        /// <summary>
        /// Turns the percentage value of a saving into money value.
        /// </summary>
        /// <param name="income"></param>
        /// <returns>The savings value in double.</returns>
        public double CalculatePercentageToMoney(double income)
        {
            var actualPercentage = MaxPercentage - SavingsPercentage;
            return Math.Round( income > 0 ? income * actualPercentage : 0, 2);
        }

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
        /// Checks if a list is empty or null.
        /// </summary>
        /// <param name="savingsList"></param>
        /// <returns>True if list is not null or empty.</returns>
        private static bool CheckIfSavingListIsNullOrEmpty(List<Saving> savingsList)
        {
            return savingsList != null && savingsList.Count > 0;
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
            return income > 0 ? income - CalculatePercentageToMoney(income) : 0;
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
                    SavingIsPossible(ref totalSavings, log, saving);
                }
                SavingIsNotPossible(log, saving);
            }
            return true;
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
        /// Outcome is logged to desktop file.
        /// </summary>
        /// <param name="totalSavings"></param>
        /// <param name="log"></param>
        /// <param name="saving"></param>
        private static void SavingIsPossible(ref double totalSavings, Logger log, Saving saving)
        {
            BudgetCalculator.totalIncome.Money -= saving.SumLeftAfterSaving(BudgetCalculator.totalIncome.Money);
            totalSavings += saving.CalculatePercentageToMoney(BudgetCalculator.totalIncome.Money);
            log.AddStringToBoughtItemsList(saving.Name , Math.Round(saving.SumLeftAfterSaving(BudgetCalculator.totalIncome.Money),2).ToString() , totalSavings.ToString());
            log.boughtItems.Clear();
            
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
