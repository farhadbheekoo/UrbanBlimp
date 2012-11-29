using System.Json;

namespace UrbanBlimp.Android
{
    static class PushNotificationSerializer
    {

        public static string Serialize(this PushNotificationRequest notification)
        {
            var jsonObj = JsonObj(notification);
            return jsonObj.ToString();
        }


        static JsonObject JsonObj(PushNotificationRequest notification)
        {
            var jsonObj = new JsonObject();

            var android = new JsonObject();

            if (notification.Payload.Alert != null)
            {
                android["alert"] = notification.Payload.Alert;
            }
            if (notification.Payload.Extra != null)
            {
                var extra = new JsonObject();
                foreach (var pair in notification.Payload.Extra)
                {
                    extra[pair.Key] = pair.Value;
                }
                android["extra"] = extra;
            }
            jsonObj["android"] = android;
            if (notification.PushIds != null)
            {
                jsonObj["apids"] = notification.PushIds.ToJsonArray();
            }
            if (notification.Aliases != null)
            {
                jsonObj["aliases"] = notification.Aliases.ToJsonArray();
            }
            if (notification.Tags != null)
            {
                jsonObj["tags"] = notification.Tags.ToJsonArray();
            }


            return jsonObj;
        }


    }
}