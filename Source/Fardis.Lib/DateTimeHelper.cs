using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Fardis
{
    public class DateTimeHelper : Fardis.IDateTimeHelper
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
    }
}
