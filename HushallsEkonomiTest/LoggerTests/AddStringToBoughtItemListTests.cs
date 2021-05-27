namespace HushallsEkonomiTest.LoggerTests
{
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

    public class AddStringToBoughtItemListTests
    {
        private readonly Logger log = new Logger();

        [Test]
        public void AddStringToBoughtItemsList_01_CheckIfListContainsBoughtItemMessage_ReturnsEqual()
        {
            log.AddStringToBoughtItemsList("LoggerTests", "0");
            var actual = log.boughtItems.Find(e => e.Contains("LoggerTests: 0 KR"));
            var expected = "LoggerTests: 0 KR";
            Assert.AreEqual(actual, expected);
            log.boughtItems.Clear();
        }
    }
}