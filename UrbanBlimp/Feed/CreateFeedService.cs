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
            request.DoRequest(postData, NewFeedIdDeSerializer.DeSerialize, callback, exceptionCallback);
        }
    }
}