using System.Json;

namespace UrbanBlimp.Android
{
    static class AddRegistrationRequestSerializer
    {

        public static string Serialize(this AddRegistrationRequest registrationRequest)
        {
            var jsonObj = JsonObj(registrationRequest);
            return jsonObj.ToString();
        }

        static JsonObject JsonObj(AddRegistrationRequest registrationRequest)
        {
            var jsonObj = new JsonObject();

            if (registrationRequest.Alias != null)
            {
                jsonObj["alias"] = registrationRequest.Alias;
            }
            jsonObj["tags"] = registrationRequest.Tags.ToJsonArray();

            return jsonObj;
        }

    }
}