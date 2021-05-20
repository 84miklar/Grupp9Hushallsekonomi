namespace HushallsEkonomiTest.LoggerTests
{
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    using System.Linq;
    public class AddStringToBoughtItemListTests
    {
        private readonly Logger log = new Logger();
        [Test]
        public void AddStringToErrorMessageList_01_CheckIfListContainsErrorMessage_ReturnsEqual()
        {
            log.AddStringToBoughtItemsList("LoggerTests", "0");
            var actual = log.boughtItems.Find(e => e.Contains("LoggerTests: 0 KR"));
            var expected = "LoggerTests: 0 KR";
            Assert.AreEqual(actual, expected);
            log.boughtItems.Clear();
        }
        [Test]
        public void AddStringToErrorMessageList_02_CheckIfListContainsErrorMessage_ReturnsNotEqual()
        {
            log.AddStringToBoughtItemsList("Test", "0");
            var actual = log.boughtItems.Find(e => e.Contains("Test"));
            var expected = "Fail";
            Assert.AreNotEqual(actual, expected);
            log.boughtItems.Clear();
        }
    }
}
