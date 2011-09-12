using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fardis
{
    public class Validator : IValidator
    {
        public bool IsValidEmail(string source)
        {
            string pattern = @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})";
            return Regex.IsMatch(source,pattern);
        }

        public bool IsValidWebAddress(string source)
        {
            string pattern = @"http([s]*)://[\w.]*";
            return Regex.IsMatch(source, pattern);
        }
    }
}
