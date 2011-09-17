using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Fardis
{
    public class DateTimeHelper : IDateTimeHelper
    {
        public string ConvertToPersianDate(DateTime? date)
        {
            if (date == null)
                return string.Empty;

            PersianCalendar calendar = new PersianCalendar();

            int day = calendar.GetDayOfMonth(date.Value);
            int month = calendar.GetMonth(date.Value);
            int year = calendar.GetYear(date.Value);

            string persian = string.Format("{0}/{1}/{2}", year, month, day);

            return persian;
        }

        public string ConvertToPersianDatePersianDigit(DateTime? date)
        {
            return FConvert.ToPersianDigit(ConvertToPersianDate(date));
        }

        public DateTime ConvertPersianToGregorianDate(string persianDate)
        {
            string englishDigitPersianDate = FConvert.ToEnglishDigit(persianDate);
            string[] tokens = englishDigitPersianDate.Split('/');

            //validation
            if (tokens.Length != 3)
                throw new ArgumentException("Persian date must have 3 tokens");

            string year = tokens[0];
            string month = tokens[1];
            string day = tokens[2];

            if (year.Length != 2 && year.Length != 4)
                throw new ArgumentException("persian year must be 2 or 4 digits");

            if (month.Length > 2 || day.Length > 2)
                throw new ArgumentException("persian month/day must have 2 digit maximum");

            if (year.Length == 2)
                year = "13" + year;

            int yearValue = Convert.ToInt32(year);
            int monthValue = Convert.ToInt32(month);
            int dayValue = Convert.ToInt32(day);

            if (monthValue < 1 || monthValue > 12)
                throw new ArgumentException("month must be between 1 and 12");

            if (dayValue < 1 || dayValue > 31)
                throw new ArgumentException("day must be between 1 and 31");

            PersianCalendar pc = new PersianCalendar();

            return pc.ToDateTime(yearValue, monthValue, dayValue, 0, 0, 0, 0);
        }

        public bool IsPersianYearLeap(int persianYear)
        {
            throw new NotImplementedException();
        }

        public string AddDatePersian(string sourcePersianDate, int day)
        {
            throw new NotImplementedException();
        }

        public string DatePartPersian(string datePart, string sourcePersianDate)
        {
            throw new NotImplementedException();
        }

        public string DateDiffPersian(string datepart, string startdate, string enddate)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPersianDate(string source)
        {
            throw new NotImplementedException();
        }
    }
}
