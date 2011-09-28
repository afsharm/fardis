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

            //correcting date with format dd/mm/yyyy
            if (month.Length == 2 && day.Length == 4 && year.Length == 2)
            {
                string temp = day;
                day = year;
                year = temp;
            }

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
            PersianCalendar pc = new PersianCalendar();

            return pc.IsLeapYear(persianYear);
        }

        public string AddDatePersian(string sourcePersianDate, int day)
        {
            DateTime source = ConvertPersianToGregorianDate(sourcePersianDate);

            DateTime addedDate = source.AddDays(day);

            string target = ConvertToPersianDatePersianDigit(addedDate);

            return target;
        }

        public string DatePartPersian(string datePart, string sourcePersianDate)
        {
            string[] tokens = FConvert.ToEnglishDigit(sourcePersianDate).Split('/');

            switch (datePart.ToLower())
            {
                case "year":
                    return tokens[0];
                case "month":
                    return tokens[1];
                case "day":
                    return tokens[2];
                default:
                    throw new ArgumentException("Invalid datePart");
            }
        }

        public string DateDiffPersian(string datepart, string startdate, string enddate)
        {
            DateTime start = ConvertPersianToGregorianDate(startdate);
            DateTime end = ConvertPersianToGregorianDate(enddate);

            TimeSpan ts = end - start;
            string retval = string.Empty;

            switch (datepart.ToLower())
            {
                case "day":
                    retval = ts.Days.ToString();
                    break;
                default:
                    throw new ArgumentException("Invalid datepart");
            }

            return retval;
        }

        public bool IsValidPersianDate(string source)
        {
            bool isValid = true;

            try
            {
                string[] tokens = FConvert.ToEnglishDigit(source).Split('/');
                PersianCalendar pc = new PersianCalendar();
                pc.ToDateTime(Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]), 0, 0, 0, 0);
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
