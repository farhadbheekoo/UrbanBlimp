using System;

namespace UrbanBlimp.Android
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(PushNotification notification, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/");
            request.Method = "POST";

            var asyncRequest = new AsyncRequest
                {
                    Request = request,
                    ReadFromResponse = o => callback(),
                    ExceptionCallback = exceptionCallback,
                    WriteToRequest = stream => notification.Serialize(stream)
                };
            asyncRequest.Execute();
        }
    }
}