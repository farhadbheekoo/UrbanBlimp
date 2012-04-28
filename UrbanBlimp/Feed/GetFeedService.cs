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
            return request.DoRequest(stream => FeedDeSerializer.DeSerialize(stream).ToList());
        }
    }
}