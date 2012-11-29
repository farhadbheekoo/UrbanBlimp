using System;

namespace UrbanBlimp.Apple
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(PushNotificationRequest request, Action<PushNotificationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/push/");
            webRequest.Method = "POST";
            //TODO: must have tags or tokens... validate

            var asyncRequest = new AsyncRequest
                                   {
                                       WriteToRequest = stream => stream.WriteToStream(request.Serialize),
                                       Request = webRequest,
                                       ReadFromResponse = o => responseCallback(new PushNotificationResponse()),
                                       ExceptionCallback = exceptionCallback,
                                       RequestContentType = "application/json"
                                   };

            asyncRequest.Execute();
        }
    }
}