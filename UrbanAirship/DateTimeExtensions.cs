using System;
using System.Globalization;

namespace UrbanBlimp
{
    internal static class DateTimeExtensions
    {
        public static string ToIso8601(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("o");
        }
        public static DateTime? ParseDate(string value)
        {
            if (value == null)
            {
                return null;
            }
            return DateTime.ParseExact(value, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}