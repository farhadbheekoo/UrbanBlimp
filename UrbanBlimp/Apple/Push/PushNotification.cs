using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class PushNotification
    {
        public PushPayload Payload;
        public List<string> Aliases;
        public Dictionary<string, string> CustomData;
        public List<string> DeviceTokens;
        public List<string> Tags;
        public List<string> ExcludeTokens;
    }
}