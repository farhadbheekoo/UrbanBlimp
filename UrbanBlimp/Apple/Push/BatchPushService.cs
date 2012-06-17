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

            var asyncRequest = new AsyncRequest
            {
                WriteToRequest = stream =>stream.WriteToStream(notifications.Serialize),
                Request = request,
                ReadFromResponse = o => callback(),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute();;
        }
    }
}