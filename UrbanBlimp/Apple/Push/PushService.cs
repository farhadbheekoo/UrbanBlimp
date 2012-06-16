using System;

namespace UrbanBlimp.Apple
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(PushNotification notification, Action callback, Action<Exception> exceptionCallback)
        {
            var postData = PushNotificationSerializer.Serialize(notification);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/");
            request.Method = "POST";
            //TODO: must have tags or tokens... validate

            var asyncRequest = new AsyncRequest
            {
                PostData = postData,
                Request = request,
                Callback = o => callback(),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); ;
        }
    }
}