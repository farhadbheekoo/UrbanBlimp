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
            var url = "https://go.urbanairship.com/api/device_tokens/?since" + dateTime.ToIso8601();
            var request = RequestBuilder.Build(url);
            request.Method = "GET";

            var asyncRequest = new AsyncRequest<List<DeviceFeedback>>
                {
                    ConvertStream = stream => FeedbackSerializer.DeSerialize(stream).ToList(),
                    Request = request,
                    Callback = callback,
                    ExceptionCallback = exceptionCallback,
                };
            asyncRequest.Execute();
        }
    }
}