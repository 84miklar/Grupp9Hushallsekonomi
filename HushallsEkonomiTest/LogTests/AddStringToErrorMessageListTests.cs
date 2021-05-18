﻿using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.SavingTests.LogTests
{
    public class AddStringToErrorMessageListTests
    {
        Logger log = new Logger();
        [Test]
        public void AddStringToErrorMessageList_01_CheckIfListContainsErrorMessage_ReturnsEqual()
        {
            log.AddStringToErrorMessagesList("LoggerTests");
            var actual = log.errorMessages.FirstOrDefault(e => e.Contains("LoggerTests"));
            var expected = "LoggerTests";
            Assert.AreEqual(actual, expected);
            log.errorMessages.Clear();
        }
        [Test]
        public void AddStringToErrorMessageList_02_CheckIfListContainsErrorMessage_ReturnsNotEqual()
        {
            log.AddStringToErrorMessagesList("Fail");
            var actual = log.errorMessages.FirstOrDefault(e => e.Contains("Fail"));
            var expected = "LoggerTests";
            Assert.AreNotEqual(actual, expected);
            log.errorMessages.Clear();
        }
    }
}