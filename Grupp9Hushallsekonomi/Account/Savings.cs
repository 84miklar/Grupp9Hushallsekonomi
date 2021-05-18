using Grupp9Hushallsekonomi.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi.Account
{
    public class Savings
    {
        public double totalSavings = 0;

        public const double MaxPercentage = 1;
        public double SavingsPercantage { get; set; }
        public string Name { get; set; }
        public Savings(string name, double percantage)
        {
            Name = name;
            SavingsPercantage = percantage;
        }
        public Savings(){}
        public double CalculatePercentageToMoney(double income)
        {
            var actualPrecentage = MaxPercentage - SavingsPercantage;
            return income > 0 ? income * actualPrecentage : 0;
          
        }
        public double SumLeftAfterSaving(double income)
        {
           return income > 0 ? income - CalculatePercentageToMoney(income) : 0;
            //if (income > 0)
            //{

            //    return income - CalculatePercentageToMoney(income);
            //}
            //return 0;
        }
        public bool IsSavingPossible(double income)
        {
            return income > 0 ? CheckSumAfterSavingAndSavingsPercentage(income) : false;
            //if (income > 0)
            //{
            //    return CheckSumAfterSavingAndSavingsPercentage(income);
            //    //if (sumAfterSaving >= 0 && SavingsPercantage <= MaxPercentage)
            //    //{
            //    //    return true;
            //    //}
            //}
            //return false;
        }

        private bool CheckSumAfterSavingAndSavingsPercentage(double income)
        {
            var sumAfterSaving = SumLeftAfterSaving(income);
            return sumAfterSaving >= 0 && SavingsPercantage <= MaxPercentage ? true : false;
        }

        /// <summary>
        /// Checks If saving withdraw is possible
        /// </summary>
        /// <param name="savingsList"></param>
        /// <returns>True if savings is withdrawn
        /// False if list is null</returns>
        public bool CheckSavings(List<Savings> savingsList)
        {
            
            var log = new Logger();
            var moneyLeft = BudgetCalculator.totalIncome.Money;
            if (moneyLeft > 0 && savingsList != null)
            {
                foreach (var saving in savingsList)
                {

                    if (saving.IsSavingPossible(moneyLeft))
                    {
                        moneyLeft -= saving.SumLeftAfterSaving(moneyLeft);
                        totalSavings += saving.CalculatePercentageToMoney(moneyLeft);
                        log.AddStringToBoughtItemsList(saving.Name);
                        log.AddStringToBoughtItemsList(saving.SumLeftAfterSaving(moneyLeft).ToString());
                        log.AddBoughtItemsListToLogger();
                    }
                    else
                    {
                        log.AddStringToErrorMessagesList($"Not enough money for {saving.Name}");
                        log.AddErrorMessagesListToLogger();
                    }
                }
                return true;
            }
            return false;
        }
    }
}
