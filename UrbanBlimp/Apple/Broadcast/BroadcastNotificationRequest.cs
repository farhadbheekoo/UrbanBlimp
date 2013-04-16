using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class BroadcastNotificationRequest
    {
        public List<string> ExcludeTokens;
        public PushPayload Payload;
    }
}