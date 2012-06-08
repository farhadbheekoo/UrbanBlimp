using System;

namespace UrbanBlimp.Feed
{
    public class ModifyFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string feedId, UpdateFeed newFeed, Action callback, Action<Exception> exceptionCallback)
        {
            var postData = UpdateFeedSerializer.Serialize(newFeed);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "PUT";
            request.DoRequest(postData, b => callback(), exceptionCallback);
        }
    }
}