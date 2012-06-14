using System;

namespace UrbanBlimp.Feed
{
    public class DeleteFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string feedId, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "DELETE";

            var asyncRequest = new AsyncRequest
            {
                Request = request,
                Callback = o => callback(),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
            
        }

    }
}