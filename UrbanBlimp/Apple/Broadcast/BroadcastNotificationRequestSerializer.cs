using System.Json;

namespace UrbanBlimp.Apple
{
    public static class BroadcastNotificationRequestSerializer
    {
        public static string Serialize(this BroadcastNotificationRequest notification)
        {
            var jsonObj = JsonObj(notification);
            return jsonObj.ToString();
        }

        static JsonObject JsonObj(BroadcastNotificationRequest notification)
        {
            var jsonObj = new JsonObject();

            jsonObj["aps"] = BatchPushRequestSerializer.JsonObject(notification.Payload);
            if (notification.ExcludeTokens != null)
            {
                jsonObj["exclude_tokens"] = notification.ExcludeTokens.ToJsonArray();
            }

            return jsonObj;
        }
    }
}