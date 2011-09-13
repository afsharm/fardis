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
            Assert.AreEqual("1390/6/22", dateTimeHelper.ConvertToPersianDate(Convert.ToDateTime("2011/09/13")));
            Assert.AreEqual(string.Empty, dateTimeHelper.ConvertToPersianDate(null));
            Assert.AreEqual("1390/1/1", dateTimeHelper.ConvertToPersianDate(Convert.ToDateTime("2011/03/21")));
            Assert.AreEqual("1389/12/29", dateTimeHelper.ConvertToPersianDate(Convert.ToDateTime("2011/03/20")));
            Assert.AreEqual("1387/12/30", dateTimeHelper.ConvertToPersianDate(Convert.ToDateTime("2009/03/20")));
            Assert.AreEqual("1388/1/1", dateTimeHelper.ConvertToPersianDate(Convert.ToDateTime("2009/03/21")));
        }

        [Test]
        public void ConvertToPersianDatePersianDigitTest()
        {
            Assert.AreEqual("۱۳۹۰/۶/۲۲", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2011/09/13")));
            Assert.AreEqual(string.Empty, dateTimeHelper.ConvertToPersianDatePersianDigit(null));
            Assert.AreEqual("۱۳۹۰/۱/۱", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2011/03/21")));
            Assert.AreEqual("۱۳۸۹/۱۲/۲۹", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2011/03/20")));
            Assert.AreEqual("۱۳۸۷/۱۲/۳۰", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2009/03/20")));
            Assert.AreEqual("۱۳۸۸/۱/۱", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2009/03/21")));
        }
    }
}
