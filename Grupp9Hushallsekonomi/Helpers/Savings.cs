using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp9Hushallsekonomi.Helpers
{
    public class Savings
    {
        public double SavingsPercantage { get; set; }
        public string Name { get; set; }
        public Savings(string name, double percantage)
        {
            Name = name;
            SavingsPercantage = percantage;
        }
        public double CalculatePercentageToMoney(double income)
        {
            double maxPrecentage = 1.0;
            var actualPrecentage = maxPrecentage - SavingsPercantage;
            return income * actualPrecentage;
        }
    }
}
