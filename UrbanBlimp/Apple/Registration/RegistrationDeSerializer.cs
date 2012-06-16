using System.IO;
using System.Json;

namespace UrbanBlimp.Apple
{
    static class RegistrationDeSerializer
    {

        public static Registration DeSerialize(Stream content)
        {
            if (content == null)
            {
                return null;
            }
            var jsonValue = JsonValue.Load(content);
            return new Registration
                       {
                           Alias = jsonValue.StringValue("alias"),
                           Badge = jsonValue.IntValue("badge"),
                           TimeZone = jsonValue.StringValue("tz"),
                           Tags = jsonValue.ListValue("tags"),
                           QuietTime = GetQuietTime(jsonValue)
                       };
        }

        static QuietTime GetQuietTime(JsonValue jsonValue)
        {
            if (jsonValue.ContainsKey("quiettime"))
            {
                var quiettime = jsonValue["quiettime"];
                return new QuietTime
                           {
                               Start = quiettime.StringValue("start"),
                               End = quiettime.StringValue("end"),
                           };
            }
            return null;
        }

    }
}