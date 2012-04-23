using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;

namespace UrbanBlimp.Apple
{
    internal static class PushNotificationSerializer
    {

        public static string Serialize(PushNotification notification)
        {
            var jsonObj = JsonObj(notification);
            return jsonObj.ToString();
        }

        static JsonObject JsonObj(PushNotification notification)
        {
            var jsonObj = new JsonObject();

            var aps = new JsonObject();

            if (notification.Payload.Alert != null)
            {
                aps["alert"] = notification.Payload.Alert;
            }
            if (notification.Payload.Badge != null)
            {
                aps["badge"] = notification.Payload.Badge;
            }
            if (notification.Payload.Sound != null)
            {
                aps["sound"] = notification.Payload.Sound;
            }
            jsonObj["aps"] = aps;
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

        public static string Serialize(IEnumerable<PushNotification> notifications)
        {

            return new JsonArray(notifications.Select(JsonObj)).ToString();
        }


        static void ValidateKey(string key)
        {
            key = key.ToLowerInvariant();
            if (key == "aps" || key == "alias" || key == "device_tokens" || key == "tags" || key == "exclude_tokens")
            {
                throw new Exception(string.Format("The key '{0}' is invalid because it is a pre defined property.", key));
            }
        }
    }
}