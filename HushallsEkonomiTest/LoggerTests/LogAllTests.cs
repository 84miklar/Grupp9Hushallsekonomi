using Grupp9Hushallsekonomi.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest.LoggerTests
{
    public class LogAllTests
    {
        private readonly Logger log = new Logger();
        [SetUp]
        public void SetUp()
        {
            var seeder = new Seeder();
            seeder.FillListWithIncome();
            seeder.FillListWithExpenses();
            seeder.FillListWithSavings();
        }
        [Test]
        public void LogAll_01_()
        {
            log.listToPrint.Add("(test)");
            log.LogAll();
            var actual = log.listToPrint.Find(e => e.Contains("(test)"));
            var expected = "(test)";
            Assert.AreEqual(actual, expected);
            log.listToPrint.Clear();
        }
    }
}
