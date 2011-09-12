using System;
using System.Collections.Generic;
using System.Text;

namespace Fardis
{
    public class EncodingHelper
    {
        /// <summary>
        /// تبدیل اولین کاراکتر رشته ورودی به کد یونیکد هگزا
        /// </summary>
        /// <param name="str">فقط کاراکتر اول در نظر گرفته می‌شود</param>
        /// <returns></returns>
        public static string GetHex(string str)
        {
            //فقط کاراکتر اول مورد بررسی قرار می‌گیرد
            return string.Format("U+{0:X4}", GetDecimal(str));
        }

        /// <summary>
        /// ‫‫‫‫‫‫‫‫‫درست مشابه GetHex اما فقط کد هگزا دسیمال را برمی‌گرداند
        /// </summary>
        public static string GetHexSimple(string character)
        {
            //فقط کاراکتر اول مورد بررسی قرار می‌گیرد
            return string.Format("{0:x4}", GetDecimal(character));
        }

        /// <summary>
        /// تبدیل اولین کاراکتر رشته ورودی به کد یونیکد دهدهی
        /// </summary>
        /// <param name="str">فقط کاراکتر اول در نظر گرفته می‌شود</param>
        /// <returns></returns>
        public static long GetDecimal(string str)
        {
            //فقط کاراکتر اول مورد بررسی قرار می‌گیرد
            byte[] b = UnicodeEncoding.BigEndianUnicode.GetBytes(str);
            return b[0] * 256 + b[1];
        }

        public static long GetDecimal(char ch)
        {
            return GetDecimal(ch.ToString());
        }

        /// <summary>
        /// تبدیل اولین کاراکتر رشته ورودی به نام یونیکدی آن
        /// </summary>
        /// <param name="str">فقط کاراکتر اول در نظر گرفته می‌شود</param>
        /// <returns></returns>
        public static string GetUnicodeName(string str)
        {
            //فقط کاراکتر اول مورد بررسی قرار می‌گیرد
            string res = string.Empty;
            long code = GetDecimal(str);

            switch (code)
            {
                case 0x6cc:
                    res = "ARABIC LETTER FARSI YEH";
                    break;
                case 0x6f0:
                    res = "EXTENDED ARABIC-INDIC DIGIT ZERO";
                    break;
                case 0x6f1:
                    res = "EXTENDED ARABIC-INDIC DIGIT ONE";
                    break;
                case 0x6f2:
                    res = "EXTENDED ARABIC-INDIC DIGIT TWO";
                    break;
                case 0x6f3:
                    res = "EXTENDED ARABIC-INDIC DIGIT THREE";
                    break;
                case 0x6f4:
                    res = "EXTENDED ARABIC-INDIC DIGIT FOUR";
                    break;
                case 0x6f5:
                    res = "EXTENDED ARABIC-INDIC DIGIT FIVE";
                    break;
                case 0x6f6:
                    res = "EXTENDED ARABIC-INDIC DIGIT SIX";
                    break;
                case 0x6f7:
                    res = "EXTENDED ARABIC-INDIC DIGIT SEVEN";
                    break;
                case 0x6f8:
                    res = "EXTENDED ARABIC-INDIC DIGIT EIGHT";
                    break;
                case 0x6f9:
                    res = "EXTENDED ARABIC-INDIC DIGIT NINE";
                    break;
                case 0x0647:
                    res = "ARABIC LETTER HEH";
                    break;
                case 0x005c:
                    res = "REVERSE SOLIDUS";
                    break;
                case 0x0627:
                    res = "ARABIC LETTER ALEF";
                    break;
                case 0x06a9:
                    res = "ARABIC LETTER KEH";
                    break;
                case 0x0643:
                    res = "ARABIC LETTER KAF";
                    break;
                case 0x0648:
                    res = "ARABIC LETTER WAW";
                    break;
                case 0x002e:
                    res = "FULL STOP";
                    break;
                case 0x002f:
                    res = "SOLIDUS";
                    break;
                case 0x200d:
                    res = "ZERO WIDTH JOINER";
                    break;
                case 0x002d:
                    res = "HYPHEN-MINUS";
                    break;
                case 0x003d:
                    res = "EQUALS SIGN";
                    break;
                case 0x00f7:
                    res = "DIVISION SIGN";
                    break;
                case 0x0021:
                    res = "EXCLAMATION MARK";
                    break;
                case 0x066c:
                    res = "ARABIC THOUSANDS SEPERATOR";
                    break;
                case 0x066b:
                    res = "ARABIC DECIMAL SEPERATOR";
                    break;
                case 0xfdfc:
                    res = "RIAL SIGN";
                    break;
                case 0x066a:
                    res = "ARABIC PERCENT SIGN";
                    break;
                case 0x00d7:
                    res = "MULTIPLICATION SIGN";
                    break;
                case 0x0026:
                    res = "AMPERSAND";
                    break;
                case 0x060c:
                    res = "ARABIC COMMA";
                    break;
                case 0x002a:
                    res = "ASTERISK";
                    break;
                case 0x0028:
                    res = "LEFT PARENTHESIS (OPENING)";
                    break;
                case 0x0029:
                    res = "RIGHT PARENTHESIS (CLOSING)";
                    break;
                case 0x0640:
                    res = "ARABIC TATWEEL";
                    break;
                case 0x002b:
                    res = "PLUS SIGN";
                    break;
                case 0x0652:
                    res = "ARABIC SUKUN";
                    break;
                case 0x064c:
                    res = "ARABIC DAMMATAN";
                    break;
                case 0x064d:
                    res = "ARABIC KASRATAN";
                    break;
                case 0x064b:
                    res = "ARABIC FATHATAN";
                    break;
                case 0x064f:
                    res = "ARABIC DAMMA";
                    break;
                case 0x0650:
                    res = "ARABIC KASRA";
                    break;
                case 0x064e:
                    res = "ARABIC FATHA";
                    break;
                case 0x0651:
                    res = "ARABIC SHADDA";
                    break;
                case 0x005d:
                    res = "RIGHT SQUARE BRACKET (CLOSING)";
                    break;
                case 0x005b:
                    res = "LEFT SQUARE BRACKET (OPENING)";
                    break;
                case 0x007d:
                    res = "RIGHT CURLY BRACKET (CLOSING)";
                    break;
                case 0x007b:
                    res = "LEFT CURLY BRACKET (OPENING)";
                    break;
                case 0x007c:
                    res = "VERTICAL LINE";
                    break;
                case 0x0624:
                    res = "ARABIC LETTER WAW WITH HAMZA ABOVE";
                    break;
                case 0x0626:
                    res = "ARABIC LETTER YEH WITH HAMZA ABOVE";
                    break;
                case 0x064a:
                    res = "ARABIC LETTER YEH";
                    break;
                case 0x0625:
                    res = "ARABIC LETTER ALEF WITH HAMZA BELOW";
                    break;
                case 0x0623:
                    res = "ARABIC LETTER ALEF WITH HAMZA ABOW";
                    break;
                case 0x0622:
                    res = "ARABIC LETTER ALEF WITH MADDA ABOVE";
                    break;
                case 0x0629:
                    res = "ARABIC LETTER TEH MARBUTA";
                    break;
                case 0x00bb:
                    res = "RIGHT-POINTING DOUBLE ANGLE QUOTATION MARK";
                    break;
                case 0x00ab:
                    res = "LEFT-POINTING DOUBLE ANGLE QUOTATION MARK";
                    break;
                case 0x003a:
                    res = "COLON";
                    break;
                case 0x061b:
                    res = "ARABIC SEMICOLON";
                    break;
                case 0x0653:
                    res = "ARABIC MADDAH ABOVE";
                    break;
                case 0x0698:
                    res = "ARABIC LETTER JEH";
                    break;
                case 0x0670:
                    res = "ARABIC LETTER SUPERSCRIPT ALEF";
                    break;
                case 0x200c:
                    res = "ZERO WIDTH NON-JOINER";
                    break;
                case 0x0654:
                    res = "ARABIC HAMZA ABOVE";
                    break;
                case 0x0621:
                    res = "ARABIC LETTER HAMZA";
                    break;
                case 0x003e:
                    res = "GREATER-THAN SIGN";
                    break;
                case 0x003c:
                    res = "LESS-THAN SIGN";
                    break;
                case 0x061f:
                    res = "ARABIC QUESTION MARK";
                    break;
                case 0x007e:
                    res = "TILDE";
                    break;
                case 0x0060:
                    res = "GRAVE ACCENT";
                    break;
                case 0x0040:
                    res = "COMMERCIAL AT";
                    break;
                case 0x0023:
                    res = "NUMBER SIGN";
                    break;
                case 0x0024:
                    res = "DOLLAR SIGN";
                    break;
                case 0x0025:
                    res = "PERCENT SIGN";
                    break;
                case 0x005e:
                    res = "CIRCUMFLEX ACCENT";
                    break;
                case 0x2022:
                    res = "BULLET";
                    break;
                case 0x200e:
                    res = "LEFT-TO-RIGHT MARK";
                    break;
                case 0x20:
                    res = "SPACE";
                    break;
                case 0x200f:
                    res = "RIGHT-TO-LEFT MARK";
                    break;
                case 0x005f:
                    res = "LOW LINE (UNDERSCORE)";
                    break;
                case 0x2212:
                    res = "MINUS SIGN";
                    break;
                case 0x00b0:
                    res = "DEGREE SIGN";
                    break;
                case 0x20ac:
                    res = "EURO SIGN";
                    break;
                case 0x202d:
                    res = "LEFT-TO-RIGHT OVERRIDE";
                    break;
                case 0x202e:
                    res = "RIGHT-TO-LEFT OVERRIDE";
                    break;
                case 0x202c:
                    res = "POP DIRECTIONAL FORMATTING";
                    break;
                case 0x202b:
                    res = "RIGHT-TO-LEFT EMBEDDING";
                    break;
                case 0x202a:
                    res = "LEFT-TO-RIGHT EMBEDDING";
                    break;
                case 0x2010:
                    res = "HYPHEN";
                    break;
                case 0x0649:
                    res = "ARABIC LETTER ALEF MAKSURA";
                    break;
                case 0x0671:
                    res = "ARABIC LETTER ALEF WASLA";
                    break;
                case 0xfd3e:
                    res = "ORNATE LEFT PARENTHESIS";
                    break;
                case 0xfd3f:
                    res = "ORNATE RIGHT PARENTHESIS";
                    break;
                case 0x003b:
                    res = "SEMICOLON";
                    break;
                case 0x0022:
                    res = "QUOTATION MARK";
                    break;
                case 0x0656:
                    res = "ARABIC SUBSCRIPT ALEF";
                    break;
                case 0x0655:
                    res = "ARABIC HAMZA BELOW";
                    break;
                case 0x2026:
                    res = "HORIZONTAL ELLIPSIS";
                    break;
                case 0x002c:
                    res = "COMMA";
                    break;
                case 0x0027:
                    res = "APOSTROPHE";
                    break;
                case 0x003f:
                    res = "QUESTION MARK";
                    break;
                default:
                    res = string.Empty;
                    break;
            }
            return res;
        }

        public static string GetHex(char p)
        {
            return GetHex(p.ToString());
        }

        public static string GetHexSimple(char character)
        {
            return GetHexSimple(character.ToString());
        }

        public static string GetUnicodeName(char p)
        {
            return GetUnicodeName(p.ToString());
        }

        /// <summary>
        /// Converts unicode character to its C# representation form
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static string GetCSharpRep(char ch)
        {
            //Work Item #4645

            return string.Format(@"\u{0:x4}", GetDecimal(ch));
        }

        public static bool HasRtlText(string text)
        {
            for (int i = 0; i < text.Length; i++)
                if (IsRtlChar(text[i]))
                    return true;

            return false;
        }
        
        public static bool IsRtlChar(char character)
        {
            return (int)character > 128;
        }
    }
}
