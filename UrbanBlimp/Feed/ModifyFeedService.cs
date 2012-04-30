namespace UrbanBlimp.Feed
{
    public class ModifyFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string feedId, UpdateFeed newFeed)
        {
            var postData = UpdateFeedSerializer.Serialize(newFeed);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "PuUT";
            request.DoRequest(postData);
        }
    }
}