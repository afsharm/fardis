using System;
namespace Fardis
{
    public interface IDateTimeHelper
    {
        string ConvertToPersianDate(DateTime? date);
        string ConvertToPersianDatePersianDigit(DateTime? date);
    }
}
