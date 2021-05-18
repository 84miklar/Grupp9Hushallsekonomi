using Grupp9Hushallsekonomi.Account;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HushallsEkonomiTest
{
    public class IsSavingPossible
    {
        [Test]
        [TestCase(1000)]
        [TestCase(500)]
        [TestCase(200)]
        public void IsSavingPossible_01_CheckWithPositiveInput_ReturnTrue(double income)
        {
            var saving = new Saving("test", 0.5);
            var actual = saving.IsSavingPossible(income);
            Assert.IsTrue(actual);
        }

        [Test]
        [TestCase(-5)]
        [TestCase(-40)]
        [TestCase(0)]
        public void IsSavingPossible_02_CheckWithNegativeInput_ReturnFalse(double income)
        {
            var saving = new Saving("test", 0.5);
            var actual = saving.IsSavingPossible(income);
            Assert.IsFalse(actual);
        }
    }
}
