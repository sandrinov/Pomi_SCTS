using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.Extensions
{
    public static class StringExtension
    {
        public static string NormalizeCarriageReturn(this string s)
        {
            String norm = s.Replace("\r\n", "");
            return norm;
        }
        public static string NormalizeBackSlash(this string s)
        {
            String norm = s.Replace("\"", "'");
            return norm;
        }
    }
}
