using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace UrbanBlimp.Apple
{
    public class FeedbackService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(DateTime dateTime, Action<List<DeviceFeedback>> callback, Action<WebException> exceptionCallback)
        {
            var url = "https://go.urbanairship.com/api/device_tokens/?since" + dateTime.ToIso8601();
            var request = RequestBuilder.Build(url);
            request.Method = "GET";
            request.DoRequest(stream => FeedbackSerializer.DeSerialize(stream).ToList(), callback, exceptionCallback);
        }
    }
}