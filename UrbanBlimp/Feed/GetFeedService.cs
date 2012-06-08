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
            request.DoRequest(stream => FeedDeSerializer.DeSerializeMultiple(stream).ToList(), callback, exceptionCallback);
        }
        public void Execute(string feedId, Action<Feed> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "Get";
            request.DoRequest(FeedDeSerializer.DeSerialize, callback, exceptionCallback);
        }
    }
}