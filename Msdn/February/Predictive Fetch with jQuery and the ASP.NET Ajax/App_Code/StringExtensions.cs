using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStuff
{
    public static class StringExtensions
    {
        public static bool IsInt32(this string content)
        {
            int number;
            bool result = Int32.TryParse(content, out number);
            return result;
        }

        public static bool IsDate(this string content)
        {
            DateTime date;
            bool result = DateTime.TryParse(content, out date);
            return result;
        }

        public static DateTime ToDate(this string content)
        {
            DateTime date;
            bool result = DateTime.TryParse(content, out date);
            if (result)
                return date;
            else
                return DateTime.MinValue;
        }

        public static int ToInt32(this string content)
        {
            int number;
            bool result = Int32.TryParse(content, out number);
            if (result)
                return number;
            else
                return Int32.MinValue;
        }
    }
}
