using System;

namespace UrbanBlimp.Apple
{
    public class FeedbackService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(FeedbackRequest request, Action<FeedbackResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var url = "https://go.urbanairship.com/api/device_tokens/feedback/?since=" + request.Since.ToIso8601();
            var webRequest = RequestBuilder.Build(url);
			webRequest.Method = "GET";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
                {
                    ReadFromResponse = stream => responseCallback(FeedbackResponseDeSerializer.DeSerialize(stream)),
                    Request = webRequest,
                    ExceptionCallback = exceptionCallback,
                };
            asyncRequest.Execute();
        }
    }
}