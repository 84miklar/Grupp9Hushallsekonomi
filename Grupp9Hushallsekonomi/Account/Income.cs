namespace Grupp9Hushallsekonomi
{
    using Grupp9Hushallsekonomi.Interface;

    /// <summary>
    /// Class to hold all incomes, like salary.
    /// </summary>
    public class Income : IAccount
    {
        public double Money { get; set; } = 0;

        public string Name { get; set; } = "";
    }
}