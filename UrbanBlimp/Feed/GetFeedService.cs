using System;

namespace UrbanBlimp.Feed
{
    public class GetFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(GetFeedRequest request, Action<GetFeedResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + request.FeedId);
            webRequest.Method = "Get";

            var asyncRequest = new AsyncRequest
            {
                ReadFromResponse = stream => responseCallback(GetFeedResponseDeSerializer.DeSerialize(stream)),
                Request = webRequest,
                ExceptionCallback = exceptionCallback,
                RequestContentType = "application/json"
            };
            asyncRequest.Execute(); 
        }
    }
}