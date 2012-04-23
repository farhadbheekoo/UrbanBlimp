using System.IO;
using System.Json;

namespace UrbanBlimp.Apple
{
    internal static class RegistrationDeSerializer
    {

        public static Registration DeSerialize(Stream content)
        {
            var jsonValue = JsonValue.Load(content);
            return new Registration
                       {
                           Alias = (string)jsonValue.Value("alias"),
                           Badge = GetBadge(jsonValue.Value("badge")),
                           TimeZone = (string)jsonValue.Value("tz"),
                           Tags = Dynamic.ToList(jsonValue.Value("tags")),
                           QuietTime = GetQuietTime(jsonValue)
                       };
        }

        static int? GetBadge(JsonValue jsonValue)
        {
            if (jsonValue == null)
            {
                return null;
            }
            return (int)jsonValue;
        }

        static QuietTime GetQuietTime(JsonValue jsonValue)
        {
            var quiettime = jsonValue.Value("quiettime");
            if (quiettime != null)
            {
                return new QuietTime
                           {
                               Start = (string)quiettime.Value("start"),
                               End = (string)quiettime.Value("end"),
                           };
            }
            return null;
        }

    }
}