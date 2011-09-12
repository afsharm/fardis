using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Fardis.Test
{
    [TestFixture]
    public class DateTimeHelperTest
    {
        private IDateTimeHelper dateTimeHelper;

        [SetUp]
        public void Setup()
        {
            dateTimeHelper = new DateTimeHelper();
        }

        [Test]
        public void ConvertToPersianDateTest()
        {
            Assert.Fail();
        }

        [Test]
        public void ConvertToPersianDatePersianDigitTest()
        {
            Assert.Fail();
        }
    }
}
