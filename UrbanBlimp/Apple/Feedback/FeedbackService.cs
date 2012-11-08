using System;
using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Apple
{
    public class FeedbackService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(DateTime dateTime, Action<List<DeviceFeedback>> callback, Action<Exception> exceptionCallback)
        {
            var url = "https://go.urbanairship.com/api/device_tokens/feedback/?since=" + dateTime.ToIso8601();
            var request = RequestBuilder.Build(url);
            request.Method = "GET";

            var asyncRequest = new AsyncRequest
                {
                    ReadFromResponse = stream => callback( FeedbackSerializer.DeSerialize(stream).ToList()),
                    Request = request,
                    ExceptionCallback = exceptionCallback,
                };
            asyncRequest.Execute();
        }
    }
}