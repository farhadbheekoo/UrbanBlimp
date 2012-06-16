using System.IO;
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
        public static void Serialize(this NewRegistration registration, Stream stream)
        {
            var jsonObj = JsonObj(registration);
            jsonObj.Save(stream);
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