using System;

namespace UrbanBlimp.Apple
{
    public class BatchPushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(BatchPushRequest request, Action<BatchPushResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/push/batch/");
			webRequest.Method = "POST";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequest = stream =>stream.WriteToStream(request.Serialize),
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new BatchPushResponse()),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute();;
        }
    }
}