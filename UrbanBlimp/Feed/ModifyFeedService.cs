using System;

namespace UrbanBlimp.Feed
{
    public class ModifyFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(ModifyFeedRequest newFeed, Action<ModifyFeedResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + newFeed.FeedId);
            webRequest.Method = "PUT";

            var asyncRequest = new AsyncRequest
                                   {
                                       WriteToRequest = stream => stream.WriteToStream(newFeed.Serialize),
                                       Request = webRequest,
                                       ReadFromResponse = o => responseCallback(new ModifyFeedResponse()),
                                       ExceptionCallback = exceptionCallback,
                                       RequestContentType = "application/json"
                                   };
            asyncRequest.Execute();
        }
    }
}