namespace UrbanBlimp.Feed
{
    public class DeleteFeedService
    {
        public IRequestBuilder RequestBuilder;
        public bool Execute(string feedId)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "DELETE";
            return request.DoRequest();
        }

    }
}