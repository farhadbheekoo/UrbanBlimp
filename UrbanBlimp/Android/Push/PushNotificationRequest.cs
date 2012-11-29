using System.Collections.Generic;

namespace UrbanBlimp.Android
{
    public class PushNotificationRequest
    {
        public PushPayload Payload;
        public List<string> Aliases;
        public List<string> PushIds;
        public List<string> Tags;
    }
}