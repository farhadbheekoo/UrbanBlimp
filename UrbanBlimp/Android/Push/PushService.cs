using System;

namespace UrbanBlimp.Android
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(PushNotificationRequest notification, Action<PushNotificationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/");
			request.Method = "POST";
			request.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
                {
                    Request = request,
                    ReadFromResponse = o => responseCallback(new PushNotificationResponse()),
                    ExceptionCallback = exceptionCallback,
                    WriteToRequest = stream => stream.WriteToStream(notification.Serialize),
                };
            asyncRequest.Execute();
        }
    }
}