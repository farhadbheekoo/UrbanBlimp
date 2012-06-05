using System;
using System.Net;

namespace UrbanBlimp.Feed
{
    public class DeleteFeedService
    {
        public IRequestBuilder RequestBuilder;
        public void Execute(string feedId, Action<bool> callback, Action<WebException> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "DELETE";
            request.DoRequest(callback, exceptionCallback);
        }

    }
}