using System;

namespace UrbanBlimp.Apple
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(PushNotification notification, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/");
            request.ContentType = "application/json";
            request.Method = "POST";
            //TODO: must have tags or tokens... validate

            var asyncRequest = new AsyncRequest
            {
                WriteToRequest = stream => notification.Serialize(stream),
                Request = request,
                ReadFromResponse = o => callback(),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute();
        }
    }
}