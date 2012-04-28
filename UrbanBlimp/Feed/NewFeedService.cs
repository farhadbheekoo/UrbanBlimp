namespace UrbanBlimp.Feed
{
    public class NewFeedService
    {
        public IRequestBuilder RequestBuilder;

        public NewFeedId Execute(NewFeed newFeed)
        {
            var postData = NewFeedSerializer.Serialize(newFeed);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            request.Method = "POST";
            return request.DoRequest(postData, NewFeedIdDeSerializer.DeSerialize);
        }
    }
}