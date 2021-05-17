using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi.Helpers
{
    public class Savings
    {
        public const double MaxPercentage = 1;
        public double SavingsPercantage { get; set; }
        public string Name { get; set; }
        public Savings(string name, double percantage)
        {
            Name = name;
            SavingsPercantage = percantage;
        }
        public double CalculatePercentageToMoney(double income)
        {
            if (income > 0)
            {

                var actualPrecentage = MaxPercentage - SavingsPercantage;
                return income * actualPrecentage;
            }
            return 0;
        }
        public double SumLeftAfterSaving(double income)
        {
            if (income > 0)
            {

                return income - CalculatePercentageToMoney(income);
            }
            return 0;
        }
        public bool IsSavingPossible(double income)
        {
            if (income > 0)
            {

                var sumAfterSaving = SumLeftAfterSaving(income);
                if (sumAfterSaving >= 0 && SavingsPercantage <= MaxPercentage)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
