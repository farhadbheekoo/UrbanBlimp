using System.Json;

namespace UrbanBlimp.Tag
{
    static class ModifyTagRequestSerializer
    {

        public static string Serialize(this ModifyTagRequest modifyTagRequest)
        {
            var jsonObj = JsonObj(modifyTagRequest);
            return jsonObj.ToString();
        }


        static JsonObject JsonObj(ModifyTagRequest modifyTagRequest)
        {
            var jsonObj = new JsonObject();

            var appleDeviceTokens = new JsonObject();
            appleDeviceTokens["add"] = modifyTagRequest.AddDeviceTokens.ToJsonArray();
            appleDeviceTokens["remove"] = modifyTagRequest.RemoveDeviceTokens.ToJsonArray();
            jsonObj["device_tokens"] = appleDeviceTokens;

            var blackBerryDevicePins = new JsonObject();
            blackBerryDevicePins["add"] = modifyTagRequest.AddDevicePins.ToJsonArray();
            blackBerryDevicePins["remove"] = modifyTagRequest.RemoveDevicePins.ToJsonArray();
            jsonObj["device_pins"] = blackBerryDevicePins;

            var androidPushIds = new JsonObject();
            androidPushIds["add"] = modifyTagRequest.AddPushIds.ToJsonArray();
            androidPushIds["remove"] = modifyTagRequest.RemovePushIds.ToJsonArray();
            jsonObj["apids"] = androidPushIds;

            return jsonObj;
        }


    }
}