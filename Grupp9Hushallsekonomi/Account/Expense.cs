namespace Grupp9Hushallsekonomi.Account
{
    using Grupp9Hushallsekonomi.Interface;

    /// <summary>
    /// Class to hold all expenses, like bills.
    /// </summary>
    public class Expense : IAccount
    {
        public double Money { get; set; } = 0;

        public string Name { get; set; } = "";
    }
}