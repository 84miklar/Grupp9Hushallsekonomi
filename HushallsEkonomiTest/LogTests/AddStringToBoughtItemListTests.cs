using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.LogTests
{
    public class AddStringToBoughtItemListTests
    {
        Logger log = new Logger();
        [Test]
        public void AddStringToErrorMessageList_01_CheckIfListContainsErrorMessage_ReturnsEqual()
        {
            log.AddStringToBoughtItemsList("LoggerTests");
            var actual = log.boughtItems.FirstOrDefault(e => e.Contains("LoggerTests"));
            var expected = "LoggerTests";
            Assert.AreEqual(actual, expected);
            log.boughtItems.Clear();
        }
        [Test]
        public void AddStringToErrorMessageList_02_CheckIfListContainsErrorMessage_ReturnsNotEqual()
        {
            log.AddStringToBoughtItemsList("Test");
            var actual = log.boughtItems.FirstOrDefault(e => e.Contains("Test"));
            var expected = "Fail";
            Assert.AreNotEqual(actual, expected);
            log.boughtItems.Clear();
        }
    }
}
