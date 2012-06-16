using System;

namespace UrbanBlimp.Feed
{
    public class CreateFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(NewFeed newFeed, Action<NewFeedId> callback, Action<Exception> exceptionCallback)
        {
            var postData = NewFeedSerializer.Serialize(newFeed);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            request.Method = "POST";

            var asyncRequest = new AsyncRequest
            {
                PostData = postData,
                Request = request,
                Callback = stream => callback(NewFeedIdDeSerializer.DeSerialize(stream)),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); 
            
        }
    }
}