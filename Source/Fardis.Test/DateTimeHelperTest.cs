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
            Assert.AreEqual("۱۳۹۰/۶/۲۲/", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2011/09/13")));
            Assert.AreEqual(string.Empty, dateTimeHelper.ConvertToPersianDatePersianDigit(null));
            Assert.AreEqual("۱۳۹۰/۱/۱", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2011/03/21")));
            Assert.AreEqual("۱۳۸۹/۱۲/۲۹", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2011/03/20")));
            Assert.AreEqual("۱۳۸۷/۱۲/۳۰", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2009/03/20")));
            Assert.AreEqual("۱۳۸۸/۱/۱", dateTimeHelper.ConvertToPersianDatePersianDigit(Convert.ToDateTime("2009/03/21")));
        }

        [Test]
        public void ConvertPersianToGregorainDateTest()
        {
            Assert.AreEqual(Convert.ToDateTime("2011/09/13"), dateTimeHelper.ConvertPersianToGregorainDate("۱۳۹۰/۶/۲۲/"));
            Assert.AreEqual(Convert.ToDateTime("2011/03/20"), dateTimeHelper.ConvertPersianToGregorainDate("۱۳۹۰/۱/۱"));
            Assert.AreEqual(Convert.ToDateTime("2011/03/20"), dateTimeHelper.ConvertPersianToGregorainDate("۱۳۸۹/۱۲/۲۹"));
            Assert.AreEqual(Convert.ToDateTime("2009/03/20"), dateTimeHelper.ConvertPersianToGregorainDate("۱۳۸۷/۱۲/۳۰"));
            Assert.AreEqual(Convert.ToDateTime("2009/03/21"), dateTimeHelper.ConvertPersianToGregorainDate("۱۳۸۸/۱/۱"));
        }

        [Test]
        public void IsPersianYearLeapTest()
        {
            Assert.IsTrue(dateTimeHelper.IsPersianYearLeap(1387));
            Assert.IsFalse(dateTimeHelper.IsPersianYearLeap(1386));
            Assert.IsFalse(dateTimeHelper.IsPersianYearLeap(1388));
        }

        [Test]
        public void AddDatePersianTest()
        {
            Assert.AreEqual("۱۳۸۵/۶/۲۰", dateTimeHelper.AddDatePersian("۱۳۸۵/۶/۱۷", 3));
            Assert.AreEqual("۱۳۸۵/۷/۱۶", dateTimeHelper.AddDatePersian("۱۳۸۵/۶/۱۷", 30));
            Assert.AreEqual("۱۳۸۶/۶/۲۰", dateTimeHelper.AddDatePersian("۱۳۸۵/۶/۱۷", 365));
        }

        [Test]
        public void DatePartPersianTest()
        {
            Assert.AreEqual("3", dateTimeHelper.DatePartPersian("month", "۱۳۹۰/۳/۱۷"));
            Assert.AreEqual("17", dateTimeHelper.DatePartPersian("day", "۱۳۹۰/۳/۱۷"));
        }

        [Test]
        public void DateDiffPersianTest()
        {
            Assert.AreEqual("24", dateTimeHelper.DateDiffPersian("day", "۱۳۹۰/۱/۱۷", "۱۳۹۰/۲/۱۰"));
            Assert.AreEqual("0", dateTimeHelper.DateDiffPersian("month", "۱۳۹۰/۱/۱۷", "۱۳۹۰/۲/۱۰"));
            Assert.AreEqual("0", dateTimeHelper.DateDiffPersian("year", "۱۳۹۰/۱/۱۷", "۱۳۹۰/۲/۱۰"));
        }

        [Test]
        public void IsValidPersianDateTest()
        {
            Assert.IsTrue(dateTimeHelper.IsValidPersianDate("1390/1/1"));
            Assert.IsTrue(dateTimeHelper.IsValidPersianDate("۱۳۸۹/۱/۶"));

            Assert.IsFalse(dateTimeHelper.IsValidPersianDate("1390/13/1"));
            Assert.IsFalse(dateTimeHelper.IsValidPersianDate("۱۳۸۹/۱۷"));
        }
    }
}
