using System;
using System.Collections.Generic;
using System.Text;

namespace Fardis
{
    /// <summary>
    /// Convert utilty class that contains converter methods for Persian/None Persian convertions.
    /// </summary>
    public class FConvert
    {
        //this class has been named FConvert instead of Convert. 
        //because there is a same class in System namespace

        /// <summary>
        /// Converts all Arabic or English digits to Persian
        /// </summary>
        /// <param name="englishOrArabicDigit">a string containing Arabic or English digits</param>
        /// <returns>a string that all its digits has been converted to Persian digits</returns>
        public static string ToPersianDigit(string englishOrArabicDigit)
        {
            //This method is based on ISIRI-6219

            //Persian digits are different from Arabic digits. Persian digits are called 
            //"Eastern Arabic-Indic digits" in Unicode standard. They start from U+06F0 while
            //Arabic digits start from U+0660.

            return englishOrArabicDigit
                .Replace("\u0030", "\u06f0") //English 0
                .Replace("\u0031", "\u06f1") //English 1
                .Replace("\u0032", "\u06f2") //English 2
                .Replace("\u0033", "\u06f3") //English 3
                .Replace("\u0034", "\u06f4") //English 4
                .Replace("\u0035", "\u06f5") //English 5
                .Replace("\u0036", "\u06f6") //English 6
                .Replace("\u0037", "\u06f7") //English 7
                .Replace("\u0038", "\u06f8") //English 8
                .Replace("\u0039", "\u06f9") //English 9
                .Replace("\u0660", "\u06f0") //Arabic 0
                .Replace("\u0661", "\u06f1") //Arabic 1
                .Replace("\u0662", "\u06f2") //Arabic 2
                .Replace("\u0663", "\u06f3") //Arabic 3
                .Replace("\u0664", "\u06f4") //Arabic 4
                .Replace("\u0665", "\u06f5") //Arabic 5
                .Replace("\u0666", "\u06f6") //Arabic 6
                .Replace("\u0667", "\u06f7") //Arabic 7
                .Replace("\u0668", "\u06f8") //Arabic 8
                .Replace("\u0669", "\u06f9"); //Arabic 9
        }

        public static string ToPersianYehKeh(string source)
        {
            throw new NotImplementedException();

            //             return englishOrArabicDigit
            //        .Replace("\u0649", "\u06cc") 
            //        .Replace("\u064a", "\u06cc")
            //        .Replace("\u063d", "\u06cc")
            //        .Replace("\u063e", "\u06cc")
            //        .Replace("\u063f", "\u06cc")
            //        .Replace("\u064a", "\u06cc")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
            //        .Replace("\u", "\u")
        }

        public static string ToAsciiOnly(string source)
        {
            throw new NotImplementedException();
        }

        public static string RemoveControlCharacters(string source)
        {
            throw new NotImplementedException();
        }

        public static string ReplaceControlCharacters(string source, string replaceCharacter)
        {
            throw new NotImplementedException();
        }

        public static string ConvertUrlBadCharacters(string source)
        {
            return source
                         .Replace('.', '_')
                         .Replace(' ', '_')
                         .Replace(',', '_')
                         .Replace('،', '_')
                         .Replace(';', '_')
                         .Replace('\\', '_')
                         .Replace('\'', '_')
                         .Replace('`', '_')
                         .Replace('-', '_')
                         .Replace('/', '_')
                         .Replace(':', '_');
        }

        public static string MakeUrlFriendly(string source)
        {
            return ConvertUrlBadCharacters(ReplaceControlCharacters(source, "_"));
        }
    }
}
