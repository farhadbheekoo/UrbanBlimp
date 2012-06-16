using System;

namespace UrbanBlimp.Feed
{
    public class ModifyFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string feedId, UpdateFeed newFeed, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.ContentType = "application/json";
            request.Method = "PUT";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequestStream = stream => newFeed.Serialize(stream),
                Request = request,
                Callback = o => callback(),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }
    }
}