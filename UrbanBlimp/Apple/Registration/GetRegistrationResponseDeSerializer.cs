using System.IO;
using System.Json;

namespace UrbanBlimp.Apple
{
    static class GetRegistrationResponseDeSerializer
    {

        public static GetRegistrationResponse DeSerialize(Stream content)
        {
            if (content == null)
            {
                return null;
            }
            var jsonValue = JsonValue.Load(content);
            return new GetRegistrationResponse
                       {
                           Alias = jsonValue.StringValue("alias"),
                           Badge = jsonValue.NullIntValue("badge"),
                           TimeZone = jsonValue.StringValue("tz"),
                           LastRegistration = jsonValue.DateValue("last_registration"),
                           Active = jsonValue.BoolValue("active"),
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