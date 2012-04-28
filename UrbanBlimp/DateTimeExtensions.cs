using System;

namespace UrbanBlimp
{
    static class DateTimeExtensions
    {
        public static string ToIso8601(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("o");
        }

        
    }
}