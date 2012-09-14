using System.Json;

namespace UrbanBlimp.Apple
{
    internal static class RegistrationSerializer
    {

        public static string Serialize(this Registration registration)
        {
            var jsonObj = JsonObj(registration);
            return jsonObj.ToString();
        }

		static JsonObject JsonObj(Registration registration)
        {
            var jsonObj = new JsonObject();


            if (registration.QuietTime != null)
            {
                var quiettime = new JsonObject();
                quiettime["start"] = registration.QuietTime.Start;
                quiettime["end"] = registration.QuietTime.End;
                jsonObj["quiettime"] = quiettime;
            }


            if (registration.Alias != null)
            {
                jsonObj["alias"] = registration.Alias;
            }
            if (registration.Badge != null)
            {
                jsonObj["badge"] = registration.Badge.Value;
            }
            if (registration.TimeZone != null)
            {
                jsonObj["tz"] = registration.TimeZone;
            }
           // jsonObj.tags = Dynamic.ListValue(registration.Tags);
            if (registration.Tags != null)
            {
                var tagArray = new JsonArray();
                foreach (var tag in registration.Tags)
                {
                    tagArray.Add(tag);
                }
                jsonObj["tags"] = tagArray;
            }

            return jsonObj;
        }

      

    }
}

