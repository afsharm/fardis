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

            var calendar = new PersianCalendar();

            var day = calendar.GetDayOfMonth(date.Value);
            var month = calendar.GetMonth(date.Value);
            var year = calendar.GetYear(date.Value);

            var persian = string.Format("{0}/{1}/{2}", year, month, day);

            return persian;
        }

        public string ConvertToPersianDatePersianDigit(DateTime? date)
        {
            return FConvert.ToPersianDigit(ConvertToPersianDate(date));
        }

        public DateTime ConvertPersianToGregorianDate(string persianDate)
        {
            var englishDigitPersianDate = FConvert.ToEnglishDigit(persianDate);
            var tokens = englishDigitPersianDate.Split('/');

            //validation
            if (tokens.Length != 3)
                throw new ArgumentException("Persian date must have 3 tokens");

            var year = tokens[0];
            var month = tokens[1];
            var day = tokens[2];

            //correcting date with format dd/mm/yyyy
            if (month.Length == 2 && day.Length == 4 && year.Length == 2)
            {
                var temp = day;
                day = year;
                year = temp;
            }

            if (year.Length != 2 && year.Length != 4)
                throw new ArgumentException("Persian year must be 2 or 4 digits");

            if (month.Length > 2 || day.Length > 2)
                throw new ArgumentException("Persian month/day must have 2 digit maximum");

            if (year.Length == 2)
                year = "13" + year;

            var yearValue = Convert.ToInt32(year);
            var monthValue = Convert.ToInt32(month);
            var dayValue = Convert.ToInt32(day);

            if (monthValue < 1 || monthValue > 12)
                throw new ArgumentException("month must be between 1 and 12");

            if (dayValue < 1 || dayValue > 31)
                throw new ArgumentException("day must be between 1 and 31");

            var pc = new PersianCalendar();

            return pc.ToDateTime(yearValue, monthValue, dayValue, 0, 0, 0, 0);
        }

        public bool IsPersianYearLeap(int persianYear)
        {
            var pc = new PersianCalendar();

            return pc.IsLeapYear(persianYear);
        }

        public string AddDatePersian(string sourcePersianDate, int day)
        {
            var source = ConvertPersianToGregorianDate(sourcePersianDate);

            var addedDate = source.AddDays(day);

            var target = ConvertToPersianDatePersianDigit(addedDate);

            return target;
        }

        public string DatePartPersian(string datePart, string sourcePersianDate)
        {
            var tokens = FConvert.ToEnglishDigit(sourcePersianDate).Split('/');

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
            var start = ConvertPersianToGregorianDate(startdate);
            var end = ConvertPersianToGregorianDate(enddate);

            var ts = end - start;
            string retval;

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
            var isValid = true;

            try
            {
                var tokens = FConvert.ToEnglishDigit(source).Split('/');
                var pc = new PersianCalendar();
                pc.ToDateTime(Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]), 0, 0, 0, 0);
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }

        public string ConvertToPersianDateTime(DateTime? date)
        {
            if (date == null)
                return string.Empty;

            var datePart = ConvertToPersianDate(date);
            var retval = string.Format("{0} - {1}", datePart, ConvertToPersianTime(date));
            return retval;
        }

        public string ConvertToPersianDateTimePersianDigit(DateTime? date)
        {
            return FConvert.ToPersianDigit(ConvertToPersianDateTime(date));
        }

        public string ConvertToPersianTime(DateTime? date)
        {
            if (date == null)
                return string.Empty;

            var retval = date.Value.ToShortTimeString();
            return retval.Replace("AM", "ق.ظ.").Replace("PM", "ب.ظ.");
        }

        public string ConvertToPersianTimePersianDigit(DateTime? date)
        {
            return FConvert.ToPersianDigit(ConvertToPersianTime(date));
        }

        public string ToLongPersianDateStringPersianDigit(DateTime? date)
        {
            if (date == null)
                return string.Empty;

            var calendar = new PersianCalendar();

            var day = calendar.GetDayOfMonth(date.Value);
            var dayOfWeek = calendar.GetDayOfWeek(date.Value);
            var month = calendar.GetMonth(date.Value);
            var year = calendar.GetYear(date.Value);

            var persianString = string.Format("{0} {1} {2} {3}", GetPersianNameOfWeek(dayOfWeek),
                                              FConvert.ToPersianDigit(day), GetPersianNameOfMonth(month),
                                              FConvert.ToPersianDigit(year));

            return persianString;
        }

        private string GetPersianNameOfMonth(int month)
        {
            string retval;
            switch (month)
            {
                case 1:
                    retval = "فروردین";
                    break;
                case 2:
                    retval = "اردیبهشت";
                    break;
                case 3:
                    retval = "خرداد";
                    break;
                case 4:
                    retval = "تیر";
                    break;
                case 5:
                    retval = "مرداد";
                    break;
                case 6:
                    retval = "شهریور";
                    break;
                case 7:
                    retval = "مهر";
                    break;
                case 8:
                    retval = "آبان";
                    break;
                case 9:
                    retval = "آذر";
                    break;
                case 10:
                    retval = "دی";
                    break;
                case 11:
                    retval = "بهمن";
                    break;
                case 12:
                    retval = "اسفند";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("month");
            }

            return retval;
        }

        private string GetPersianNameOfWeek(DayOfWeek dayOfWeek)
        {
            string retval;

            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    retval = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    retval = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    retval = "سه‌شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    retval = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    retval = "پنج‌شنبه";
                    break;
                case DayOfWeek.Friday:
                    retval = "جمعه";
                    break;
                case DayOfWeek.Saturday:
                    retval = "شنبه";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("dayOfWeek");
            }

            return retval;
        }
    }
}
