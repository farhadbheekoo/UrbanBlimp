using System;

namespace UrbanBlimp.Apple
{
    public class BroadcastService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(BroadcastNotificationRequest request, Action<BroadcastNotificationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/push/broadcast/");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
                                   {
                                       WriteToRequest = stream => stream.WriteToStream(request.Serialize),
                                       Request = webRequest,
                                       ReadFromResponse = o => responseCallback(new BroadcastNotificationResponse()),
                                       ExceptionCallback = exceptionCallback,
                                   };

            asyncRequest.Execute();
        }
    }
}