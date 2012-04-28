using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class BatchPushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(IEnumerable<PushNotification> notifications)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/batch/");
            request.Method = "POST";
            var postData = PushNotificationSerializer.Serialize(notifications);
            request.DoRequest(postData);
        }
    }
}