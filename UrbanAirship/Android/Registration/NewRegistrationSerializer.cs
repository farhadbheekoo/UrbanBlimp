using System.Json;

namespace UrbanBlimp.Android
{
    static class NewRegistrationSerializer
    {

        public static string Serialize(NewRegistration registration)
        {
            var jsonObj = JsonObj(registration);
            return jsonObj.ToString();
        }

        static JsonObject JsonObj(NewRegistration registration)
        {
            var jsonObj = new JsonObject();

            if (registration.Alias != null)
            {
                jsonObj["alias"] = registration.Alias;
            }
            jsonObj["tags"] = registration.Tags.ToJsonArray();

            return jsonObj;
        }

    }
}