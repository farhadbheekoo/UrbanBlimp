using System.Json;

namespace UrbanBlimp.Apple
{
    static class PushNotificationRequestSerializer
    {

        public static string Serialize(this PushNotificationRequest notification)
        {
            var jsonObj = JsonObj(notification);
            return jsonObj.ToString();
        }


        static JsonObject JsonObj(PushNotificationRequest notification)
        {
            var jsonObj = new JsonObject();

            jsonObj["aps"] = BatchPushRequestSerializer.JsonObject(notification.Payload);
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
                    BatchPushRequestSerializer.ValidateKey(pair.Key);
                    jsonObj[pair.Key] = pair.Value;
                }
            }

            return jsonObj;
        }

  
    }
}