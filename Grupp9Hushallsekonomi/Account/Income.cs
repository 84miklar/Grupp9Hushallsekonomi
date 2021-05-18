namespace Grupp9Hushallsekonomi
{
    using Grupp9Hushallsekonomi.Interface;

    /// <summary>
    /// Class to hold all incomes, like salary.
    /// </summary>
    public class Income : IAccount
    {
        /// <summary>
        /// Property to set the value of the income.
        /// </summary>
        public double Money { get; set; } = 0;

        /// <summary>
        /// Property to set the name of the income.
        /// </summary>
        public string Name { get; set; } = "";
    }
}
