using System;
using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Feed
{
    public class GetFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(Action<List<Feed>> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            request.Method = "Get";

            var asyncRequest = new AsyncRequest<List<Feed>>
            {
                 ConvertStream = stream => FeedDeSerializer.DeSerializeMultiple(stream).ToList(),
                Request = request,
                Callback = callback,
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }

        public void Execute(string feedId, Action<Feed> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "Get";

            var asyncRequest = new AsyncRequest<Feed>
            {
                ConvertStream = stream => FeedDeSerializer.DeSerialize(stream),
                Request = request,
                Callback = callback,
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }
    }
}