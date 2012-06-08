using System;
using System.Net;

namespace UrbanBlimp.Feed
{
    public class ModifyFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string feedId, UpdateFeed newFeed, Action callback, Action<WebException> exceptionCallback)
        {
            var postData = UpdateFeedSerializer.Serialize(newFeed);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "PUT";
            request.DoRequest(postData, b => callback(), exceptionCallback);
        }
    }
}