namespace Grupp9Hushallsekonomi.Interface
{
    /// <summary>
    /// Interface for all accounts. Holds properties Money and Name.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Property to set the value of a transaction.
        /// </summary>
        public double Money { get; set; }
        /// <summary>
        /// Property to set the name of a transaction.
        /// </summary>
        public string Name { get; set; }
    }
}
