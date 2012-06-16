using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;

namespace UrbanBlimp.Android
{
    internal static class PushNotificationSerializer
    {

        public static string Serialize(PushNotification notification)
        {
            var jsonObj = JsonObj(notification);
            return jsonObj.ToString();
        }
        public static void Serialize(this PushNotification notification, Stream stream)
        {
            var jsonObj = JsonObj(notification);
            jsonObj.Save(stream);
        }

        static JsonObject JsonObj(PushNotification notification)
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

        public static string Serialize(IEnumerable<PushNotification> notifications)
        {

            return new JsonArray(notifications.Select(JsonObj)).ToString();
        }

    }
}