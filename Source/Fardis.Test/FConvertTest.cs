using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Fardis;

namespace Fardis.Test
{
    //tests based on NUnit 2.5.5.10112
    [TestFixture]
    public class FConvertTest
    {
        [Test]
        public void ToPersianDigit()
        {
            string[] strs = { 
                                "123", "۱۲۳",
                                "afshar3", "afshar۳",
                                "سعید۳۵", "سعید۳۵",
                                "دماوند 3۴4", "دماوند ۳۴۴",
                                "٤٤٤٧٤٧", "۴۴۴۷۴۷",
                                "Persia", "Persia"
                            };

            for (int i = 0; i < strs.Length; i = i + 2)
                Assert.AreEqual(strs[i + 1], FConvert.ToPersianDigit(strs[i]));
        }

        [Test]
        public void ToPersianYehKehTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                @"متوقف سازي حملات خودكار تزريق اس كيوال در IIS from .NET Tips",
                @"نبرد مربياني هر دو از خانواده ي آبي كه به قول امير حاج رضايي چشم ديدن همديگر",
                @"آثار به دست آمده از تپه ي باستاني گيان در شهرستان نهاوند نشان دهنده ي سكونت اقوام بومي ايراني در اين منطقه در 37 قرن",
                @"طرح راه در جنوب كرمان در حال اجراست ... كرمان- وزير راه و شهرسازي گفت:",
                @"در ایام ماه مبارک رمضان سی جزء قران کریم توسط کارکنان آموزش وپرورش"
            };

            string[] expected = new string[testCount]
            {
                @"متوقف سازی حملات خودکار تزریق اس کیوال در IIS from .NET Tips",
                @"نبرد مربیانی هر دو از خانواده ی آبی که به قول امیر حاج رضایی چشم دیدن همدیگر",
                @"آثار به دست آمده از تپه ی باستانی گیان در شهرستان نهاوند نشان دهنده ی سکونت اقوام بومی ایرانی در این منطقه در 37 قرن",
                @"طرح راه در جنوب کرمان در حال اجراست ... کرمان- وزیر راه و شهرسازی گفت:",
                @"در ایام ماه مبارک رمضان سی جزء قران کریم توسط کارکنان آموزش وپرورش"
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected[i], FConvert.ToPersianYehKeh(raw[i]), i.ToString());
        }

        [Test]
        public void ToAsciiOnlyTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                @"e/آگهي/6145788/به‌يك‌خانم‌برنامه‌نويس‌آشنا-به.html",
                @"1390/6/20 الی 1390/6/21",
                @"منطقه یافت آباد نیازمندی",
                @"یازمند , می باشد: SQL",
                @"Google tells Iranian Gmail users to beware of suspicious prompts "
            };

            string[] expected = new string[testCount]
            {
                @"e//6145788/-.html",
                @"1390/6/20  1390/6/21",
                @"   ",
                @" ,  : SQL",
                @"Google tells Iranian Gmail users to beware of suspicious prompts "
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected[i], FConvert.ToAsciiOnly(raw[i]), i.ToString());
        }

        [Test]
        public void RemoveControlCharactersTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                @"e/آگهي/6145788/به‌يك‌خانم‌برنامه‌نويس‌آشنا-به.html",
                @"می‌توان رفت",
                @"یک دو سه جهار",
                @"مراسم نستیب kjshdf oeiwoieur مسیبسیب",
                @"Google tells Iranian Gmail users to beware of suspicious prompts "
            };

            string[] expected = new string[testCount]
            {
                @"e/آگهي/6145788/بهيكخانمبرنامهنويسآشنا-به.html",
                @"میتوان رفت",
                @"یک دو سه جهار",
                @"مراسم نستیب kjshdf oeiwoieur مسیبسیب",
                @"Google tells Iranian Gmail users to beware of suspicious prompts "
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected[i], FConvert.RemoveControlCharacters(raw[i]), i.ToString());
        }

        [Test]
        public void ReplaceControlCharactersTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                @"gq7cv-.,jgh]g/منی‏‎سیبت‫سیبت‬سیبنتا۳۴۵ بمی یوــ",
                @"‎بینتlkjf8‪‬‫ewpمنیبل-‪ثصگذmcvkjq-     dxfglk0e",
                @"f,mo‏i`cv;l/زذxxیبلجحص",
                @"سیبٌ٫سیسی‬بمنخ۹LKF‪POO+}:M<N<LKDJ",
                "jh\u202ejپالعJ*N)]غhg"
            };

            string[] expected1 = new string[testCount]
            {
                @"gq7cv-.,jgh]g/منی__سیبت_سیبت_سیبنتا۳۴۵ بمی یوــ",
                @"_بینتlkjf8___ewpمنیبل-_ثصگذmcvkjq-     dxfglk0e",
                @"f,mo_i`cv;l/زذxxیبلجحص",
                @"سیبٌ٫سیسی_بمنخ۹LKF_POO+}:M<N<LKDJ",
                "jh_jپالعJ*N)]غhg"
            };

            string[] expected2 = new string[testCount]
            {
                @"gq7cv-.,jgh]g/منی@@سیبت@سیبت@سیبنتا۳۴۵ بمی یوــ",
                @"@بینتlkjf8@@@ewpمنیبل-@ثصگذmcvkjq-     dxfglk0e",
                @"f,mo@i`cv;l/زذxxیبلجحص",
                @"سیبٌ٫سیسی@بمنخ۹LKF@POO+}:M<N<LKDJ",
                "jh@jپالعJ*N)]غhg"
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected1[i], FConvert.ReplaceControlCharacters(raw[i], "_"), i.ToString());

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected2[i], FConvert.ReplaceControlCharacters(raw[i], "@"), i.ToString());
        }

        [Test]
        public void ConvertUrlBadCharactersTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                @"::df4bنیهق",
                @";xdkjfhs;_837\\..,,fffنینیه",
                @"دص۸۲dfg';psdf",
                @"ckj`1-r,cm",
                @"dfkjg8w3mdkdjldkjg"
            };

            string[] expected = new string[testCount]
            {
                @"__df4bنیهق",
                @"_xdkjfhs__837______fffنینیه",
                @"دص۸۲dfg__psdf",
                @"ckj_1_r_cm",
                @"dfkjg8w3mdkdjldkjg"
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected[i], FConvert.ConvertUrlBadCharacters(raw[i]), i.ToString());
        }

        [Test]
        public void MakeUrlFriendlyTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                @"http://iran.ir/hhhh/jh",
                @"این یک تست است. ولی مهم است،",
                @"",
                @"۳۴ققف۴۴۹۸۹۸ثقف8‫487.aspx.cs",
                @"‪سیسیبLKFL:,dsfef"
            };

            string[] expected = new string[testCount]
            {
                @"http___iran_ir_hhhh_jh",
                @"این_یک_تست_است__ولی_مهم_است_",
                @"",
                @"۳۴ققف۴۴۹۸۹۸ثقف8_487_aspx_cs",
                @"_سیسیبLKFL__dsfef"
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected[i], FConvert.MakeUrlFriendly(raw[i]), i.ToString());
        }

        [Test]
        public void ToPersianTotalTest()
        {
            const int testCount = 5;

            string[] raw = new string[testCount]
            {
                "dkيي30میب۰ي۳7۰dfgpk94l48kdfl۱منكتیبلخ۴",
                "بلاک-۳کكظٓيمسیدطصقجغهو.طذ",
                "رپدظطرظط.ىرزضثصهف۰۹۸۴نتب",
                "پوكررظططظ۷۳۲۴۰-بیبل",
                "/پزرذ۰۹۰۴۵مندی١نسح۹بنکمتیس"
            };

            string[] expected = new string[testCount]
            {
                "dkیی۳۰میب۰ی۳۷۰dfgpk۹۴l۴۸kdfl۱منکتیبلخ۴",
                "بلاک-۳ککظٓیمسیدطصقجغهو.طذ",
                "رپدظطرظط.یرزضثصهف۰۹۸۴نتب",
                "پوکررظططظ۷۳۲۴۰-بیبل",
                "/پزرذ۰۹۰۴۵مندی۱نسح۹بنکمتیس"
            };

            for (int i = 0; i < testCount; i = i + 1)
                Assert.AreEqual(expected[i], FConvert.ToPersianTotal(raw[i]), i.ToString());
        }
    }
}
