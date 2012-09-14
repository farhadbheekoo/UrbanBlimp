using System;

namespace UrbanBlimp.Feed
{
    public class CreateFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(NewFeed newFeed, Action<NewFeedId> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            request.Method = "POST";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequest = stream => stream.WriteToStream(newFeed.Serialize),
                Request = request,
                ReadFromResponse = stream => callback(NewFeedIdDeSerializer.DeSerialize(stream)),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); 
            
        }
    }
}