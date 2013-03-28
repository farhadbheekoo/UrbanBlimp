using System;

namespace UrbanBlimp.Feed
{
    public class DeleteFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(DeleteFeedRequest request, Action<DeleteFeedResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + request.FeedId);
            webRequest.Method = "DELETE";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new DeleteFeedResponse()),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
            
        }

    }
}