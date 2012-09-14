using System;

namespace UrbanBlimp.Apple
{
    public static class Badge
    {
        public static string Increment()
        {
            return "+1";
        }
        public static string SetTo(int value)
        {
            return value.ToString();
        }

        public static string Auto()
        {
            return "auto";
        }

        public static string Increment(int by)
        {
            if (by > 0)
            {
                return "+" + by;
            }
            if (by < 0)
            {
                return by.ToString();
            }
            return "auto";
        }

        public static string Decrement()
        {
            return "-1";
        }

        public static string Decrement(int by)
        {
            if (by > 0)
            {
                return "-" + by;
            }
            if (by < 0)
            {
                return "+" + Math.Abs(by).ToString();
            }
            return "auto";
        }
    }
}