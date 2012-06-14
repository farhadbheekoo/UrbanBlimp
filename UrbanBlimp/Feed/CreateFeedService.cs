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

            var asyncRequest = new AsyncRequest<NewFeedId>
            {
                PostData = postData,
                ConvertStream = NewFeedIdDeSerializer.DeSerialize,
                Request = request,
                Callback = callback,
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); 
            
        }
    }
}