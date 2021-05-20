namespace HushallsEkonomiTest.SavingTests.LoggerTests
{
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;
    using System.Linq;
    public class AddStringToErrorMessageListTests
    {
        private readonly Logger log = new Logger();
        [Test]
        public void AddStringToErrorMessageList_01_CheckIfListContainsErrorMessage_ReturnsEqual()
        {
            log.AddStringToErrorMessagesList("LoggerTests");
            var actual = log.errorMessages.Find(e => e.Contains("LoggerTests"));
            var expected = "LoggerTests";
            Assert.AreEqual(actual, expected);
            log.errorMessages.Clear();
        }

        [Test]
        public void AddStringToErrorMessageList_02_CheckIfListContainsErrorMessage_ReturnsNotEqual()
        {
            log.AddStringToErrorMessagesList("Test");
            var actual = log.errorMessages.Find(e => e.Contains("Test"));
            var expected = "Fail";
            Assert.AreNotEqual(actual, expected);
            log.errorMessages.Clear();
        }
    }
}
