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

        public DateTime ConvertPersianToGregorainDate(string persianDate)
        {
            throw new NotImplementedException();
        }


        DateTime IDateTimeHelper.ConvertPersianToGregorainDate(string persianDate)
        {
            throw new NotImplementedException();
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
