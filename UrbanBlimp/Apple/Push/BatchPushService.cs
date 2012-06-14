using System;
using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class BatchPushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(IEnumerable<PushNotification> notifications, Action<Exception> exceptionCallback, Action callback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/batch/");
            request.Method = "POST";
            var postData = PushNotificationSerializer.Serialize(notifications);

            var asyncRequest = new AsyncRequest
            {
                PostData = postData,
                Request = request,
                Callback = o => callback(),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute();;
        }
    }
}