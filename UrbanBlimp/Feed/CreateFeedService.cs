using System;

namespace UrbanBlimp.Feed
{
    public class CreateFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(NewFeed newFeed, Action<NewFeedId> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            request.ContentType = "application/json";
            request.Method = "POST";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequestStream = stream => newFeed.Serialize(stream),
                Request = request,
                Callback = stream => callback(NewFeedIdDeSerializer.DeSerialize(stream)),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); 
            
        }
    }
}