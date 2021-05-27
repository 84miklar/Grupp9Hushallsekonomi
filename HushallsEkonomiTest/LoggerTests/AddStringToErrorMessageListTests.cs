namespace HushallsEkonomiTest.SavingTests.LoggerTests
{
    using Grupp9Hushallsekonomi.Helpers;
    using NUnit.Framework;

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
    }
}