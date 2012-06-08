using System;

namespace UrbanBlimp.Feed
{
    public class DeleteFeedService
    {
        public IRequestBuilder RequestBuilder;
        public void Execute(string feedId, Action<bool> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "DELETE";
            request.DoRequest(callback, exceptionCallback);
        }

    }
}