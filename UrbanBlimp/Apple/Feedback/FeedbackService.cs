using System;
using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Apple
{
    public class FeedbackService
    {
        public IRequestBuilder RequestBuilder;

        public List<DeviceFeedback> Execute(DateTime dateTime)
        {
            var url = "https://go.urbanairship.com/api/device_tokens/?since" + dateTime.ToIso8601();
            var request = RequestBuilder.Build(url);
            request.Method = "GET";
            return request.DoRequest(stream => FeedbackSerializer.DeSerialize(stream).ToList());
        }
    }
}