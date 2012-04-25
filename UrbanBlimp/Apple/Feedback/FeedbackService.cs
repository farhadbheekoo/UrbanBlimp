using System;
using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Apple
{
    public class FeedbackService
    {
        public IRequestBuilder RequestBuilder ;

        public IEnumerable<DeviceFeedback> Execute(DateTime dateTime)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/?since" + dateTime.ToIso8601());
            request.Method = "GET";
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                return FeedbackSerializer.DeSerialize(responseStream).ToList();
            }
        }
    }
}