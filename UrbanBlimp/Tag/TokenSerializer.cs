using System.Json;

namespace UrbanBlimp.Tag
{
    internal static class TokenSerializer
    {

        public static string Serialize(Tokens tokens)
        {
            var jsonObj = JsonObj(tokens);
            return jsonObj.ToString();
        }

        static JsonObject JsonObj(Tokens tokens)
        {
            var jsonObj = new JsonObject();

            var appleDeviceTokens = new JsonObject();
            appleDeviceTokens["add"] = tokens.AddDeviceTokens.ToJsonArray();
            appleDeviceTokens["remove"] = tokens.RemoveDeviceTokens.ToJsonArray();
            jsonObj["device_tokens"] = appleDeviceTokens;

            var blackBerryDevicePins = new JsonObject();
            blackBerryDevicePins["add"] = tokens.AddDevicePins.ToJsonArray();
            blackBerryDevicePins["remove"] = tokens.RemoveDevicePins.ToJsonArray();
            jsonObj["device_pins"] = blackBerryDevicePins;

            var androidPushIds = new JsonObject();
            androidPushIds["add"] = tokens.AddPushIds.ToJsonArray();
            androidPushIds["remove"] = tokens.RemovePushIds.ToJsonArray();
            jsonObj["apids"] = androidPushIds;

            return jsonObj;
        }


    }
}