using System;
using System.Collections.Generic;
using System.Globalization;
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
            return source
               .Replace("\u0649", "\u06cc")
               .Replace("\u064a", "\u06cc")
               .Replace("\u063d", "\u06cc")
               .Replace("\u063e", "\u06cc")
               .Replace("\u063f", "\u06cc")
               .Replace("\u064a", "\u06cc")
               .Replace("\u06aa", "\u06a9")
               .Replace("\u0643", "\u06a9")
               .Replace("\u06ab", "\u06a9");
        }

        public static string ToAsciiOnly(string source)
        {
            string retval = string.Empty;

            for (int i = 0; i < source.Length; i++)
                if ((int)source[i] < 128)
                    retval += source[i];

            return retval;
        }

        public static string RemoveControlCharacters(string source)
        {
            return ReplaceControlCharacters(source, string.Empty);
        }

        public static string ReplaceControlCharacters(string source, string replaceCharacter)
        {
            return source
                .Replace("\u202a", replaceCharacter)
                .Replace("\u202b", replaceCharacter)
                .Replace("\u202c", replaceCharacter)
                .Replace("\u202d", replaceCharacter)
                .Replace("\u202e", replaceCharacter)
                .Replace("\u200e", replaceCharacter)
                .Replace("\u200f", replaceCharacter)
                .Replace("\u200c", replaceCharacter)
                .Replace("\u2004", replaceCharacter);
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

        public static string ToPersianTotal(string source)
        {
            return ToPersianDigit(ToPersianYehKeh(source));
        }

        public static string ToEnglishDigit(string persianOrArabicDigit)
        {
            //This method is based on ISIRI-6219

            //Persian digits are different from Arabic digits. Persian digits are called 
            //"Eastern Arabic-Indic digits" in Unicode standard. They start from U+06F0 while
            //Arabic digits start from U+0660.

            return persianOrArabicDigit
                .Replace("\u06f0", "\u0030") //English 0
                .Replace("\u06f1", "\u0031") //English 1
                .Replace("\u06f2", "\u0032") //English 2
                .Replace("\u06f3", "\u0033") //English 3
                .Replace("\u06f4", "\u0034") //English 4
                .Replace("\u06f5", "\u0035") //English 5
                .Replace("\u06f6", "\u0036") //English 6
                .Replace("\u06f7", "\u0037") //English 7
                .Replace("\u06f8", "\u0038") //English 8
                .Replace("\u06f9", "\u0039") //English 9
                .Replace("\u0660", "\u0030") //Arabic 0
                .Replace("\u0661", "\u0031") //Arabic 1
                .Replace("\u0662", "\u0032") //Arabic 2
                .Replace("\u0663", "\u0033") //Arabic 3
                .Replace("\u0664", "\u0034") //Arabic 4
                .Replace("\u0665", "\u0035") //Arabic 5
                .Replace("\u0666", "\u0036") //Arabic 6
                .Replace("\u0667", "\u0037") //Arabic 7
                .Replace("\u0668", "\u0038") //Arabic 8
                .Replace("\u0669", "\u0039"); //Arabic 9
        }

        public static string ToPersianDigit(int englishOrArabicDigit)
        {
            return ToPersianDigit(englishOrArabicDigit.ToString(CultureInfo.InvariantCulture));
        }
    }
}
