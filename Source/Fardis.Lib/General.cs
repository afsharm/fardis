using System;
using System.Collections.Generic;
using System.Text;

namespace Fardis
{
    /// <summary>
    /// General operation realted to Fardis project
    /// </summary>
    public class General
    {
        /// <summary>
        /// Generates URL link of site fileformat.info
        /// </summary>
        public static string GenerateLink(char character)
        {
            string hexCode = EncodingHelper.GetHexSimple(character);
            string baseLink = "http://www.fileformat.info/info/unicode/char/{0}/index.htm";

            string retval = string.Format(baseLink, hexCode.ToLower());

            return retval;
        }
    }
}
