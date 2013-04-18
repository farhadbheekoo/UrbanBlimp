using System;
using System.Json;
using System.Linq;

namespace UrbanBlimp.Apple
{
    static class BatchPushRequestSerializer
    {

        static JsonObject JsonObj(PushNotification notification)
        {
            var jsonObj = new JsonObject();

            jsonObj["aps"] = JsonObject(notification.Payload);
            if (notification.DeviceTokens != null)
            {
                jsonObj["device_tokens"] = notification.DeviceTokens.ToJsonArray();
            }
            if (notification.Aliases != null)
            {
                jsonObj["aliases"] = notification.Aliases.ToJsonArray();
            }
            if (notification.Tags != null)
            {
                jsonObj["tags"] = notification.Tags.ToJsonArray();
            }
            if (notification.ExcludeTokens != null)
            {
                jsonObj["exclude_tokens"] = notification.ExcludeTokens.ToJsonArray();
            }

            if (notification.CustomData != null)
            {
                foreach (var pair in notification.CustomData)
                {
                    ValidateKey(pair.Key);
                    jsonObj[pair.Key] = pair.Value;
                }
            }

            return jsonObj;
        }

        public static JsonObject JsonObject(PushPayload pushPayload)
        {
            var aps = new JsonObject();

            if (pushPayload.Alert != null)
            {
                aps["alert"] = pushPayload.Alert;
            }
            if (pushPayload.Badge != null)
            {
                if (pushPayload.Badge is string)
                {
                    aps["badge"] = pushPayload.Badge as string;
                }
                else if (pushPayload.Badge is int)
                {
                    aps["badge"] = (int)pushPayload.Badge;
                }
                else
                {
                    throw new Exception("Badge is not in valid format");
                }
            }
            if (pushPayload.Sound != null)
            {
                aps["sound"] = pushPayload.Sound;
            }
            return aps;
        }

        public static string Serialize(this BatchPushRequest request)
        {
            return new JsonArray(request.Notifications.Select(JsonObj)).ToString();
        }


        public static void ValidateKey(string key)
        {
            key = key.ToLowerInvariant();
            if (key == "aps" || key == "alias" || key == "device_tokens" || key == "tags" || key == "exclude_tokens")
            {
                throw new Exception(string.Format("The key '{0}' is invalid because it is a pre defined property.", key));
            }
        }
    }
}