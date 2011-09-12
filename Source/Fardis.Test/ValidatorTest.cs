using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Fardis.Test
{
    [TestFixture]
    public class ValidatorTest
    {
        private IValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new Validator();
        }

        [Test]
        public void IsValidEmailTest()
        {
            Assert.IsTrue(validator.IsValidEmail("info@tehran.ir"), "1");
            Assert.IsTrue(validator.IsValidEmail("my_Name@host.com"), "2");
            Assert.IsTrue(validator.IsValidEmail("your.name@gmail.com"), "3");
            Assert.IsTrue(validator.IsValidEmail("your.name@yahoo.co.uk"), "4");
            Assert.IsTrue(validator.IsValidEmail("123@456.org"), "5");
            Assert.IsTrue(validator.IsValidEmail("master@ua.ac.ir"), "6");

            Assert.IsFalse(validator.IsValidEmail("@"), "7");
            Assert.IsFalse(validator.IsValidEmail("@yahoo.com"), "8");
            Assert.IsFalse(validator.IsValidEmail("reza@gmail"), "9");
            Assert.IsFalse(validator.IsValidEmail("سلام@hotmail.com"), "10");
            Assert.IsFalse(validator.IsValidEmail("reza@شما.com"), "11");
            Assert.IsFalse(validator.IsValidEmail("s.h.j@."), "12");
            Assert.IsFalse(validator.IsValidEmail("yyy@"), "13");
            //Assert.IsFalse(validator.IsValidEmail("111@rrr@tehran.com"), "14");
            Assert.IsFalse(validator.IsValidEmail("somesite.net"), "15");
        }

        [Test]
        public void IsValidWebAddressTest()
        {
            Assert.IsTrue(validator.IsValidWebAddress("http://172.16.0.1:8090/corporate/servlet/CyberoamHTTPClient"), "1");
            Assert.IsTrue(validator.IsValidWebAddress("https://www.google.com/analytics/settings/?pli=1"), "2");
            Assert.IsTrue(validator.IsValidWebAddress("http://karvis.ir/Login.aspx?ReturnUrl=%2frtgg%2page1.aspx"), "3");
            Assert.IsTrue(validator.IsValidWebAddress("https://mail.google.com/mail/?shva=1#inbox"), "4");
            Assert.IsTrue(validator.IsValidWebAddress("https://pib24.com/webbank/resources/jsp/ib.jsp?UserN=7364773"), "5");
            Assert.IsTrue(validator.IsValidWebAddress("https://www.google.com/reader/view/?tab=my#overview-page"), "6");
            Assert.IsTrue(validator.IsValidWebAddress("http://www.rahnama.com/component/mtree/%DA%AF%D8%B1%D9%88%D9%87/35179/%D8%A8%D8%B1%D9%86%D8%A7%D9%85%D9%87-%D9%86%D9%88%D9%8A%D8%B3.html"), "7");
            Assert.IsTrue(validator.IsValidWebAddress("http://karvis.ir/Job/642.aspx/%D8%AA%D8%B3%D9%84%D8%B7_%DA%A9%D8%A7%D9%85%D9%84_%D8%A8%D9%87_#C___%D8%AD%D8%B1%D9%81%D9%87_%D8%A7%DB%8C_"), "8");
            Assert.IsTrue(validator.IsValidWebAddress("http://myown.com/"), "9");

            Assert.IsFalse(validator.IsValidWebAddress("asite.com"), "10");
            Assert.IsFalse(validator.IsValidWebAddress("httpW://site1.com"), "11");
            //Assert.IsFalse(validator.IsValidWebAddress("http://123"), "12");
            //Assert.IsFalse(validator.IsValidWebAddress("http://somesite.org//"), "13");
            Assert.IsFalse(validator.IsValidWebAddress("?mysite2.com"), "14");
            Assert.IsFalse(validator.IsValidWebAddress("mailto:saeed@reza.com"), "15");
        }
    }
}
