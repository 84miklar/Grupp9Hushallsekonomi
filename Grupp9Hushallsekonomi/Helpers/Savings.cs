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
    }
}
