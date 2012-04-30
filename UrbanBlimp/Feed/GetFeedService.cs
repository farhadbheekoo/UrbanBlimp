using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Feed
{
    public class GetFeedService
    {
        public IRequestBuilder RequestBuilder;

        public List<Feed> Execute()
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            request.Method = "Get";
            return request.DoRequest(stream => FeedDeSerializer.DeSerializeMultiple(stream).ToList());
        }
        public Feed Execute(string feedId)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/" + feedId);
            request.Method = "Get";
            return request.DoRequest(FeedDeSerializer.DeSerialize);
        }
    }
}