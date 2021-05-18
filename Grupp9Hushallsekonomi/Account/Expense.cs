namespace Grupp9Hushallsekonomi.Account
{
    using Grupp9Hushallsekonomi.Interface;

    /// <summary>
    /// Class to hold all expenses, like bills.
    /// </summary>
    public class Expense : IAccount
    {
        /// <summary>
        /// Property to set the value of the expense.
        /// </summary>
        public double Money { get; set; } = 0;

        /// <summary>
        /// Property to set the name of the expense.
        /// </summary>
        public string Name { get; set; } = "";
    }
}
