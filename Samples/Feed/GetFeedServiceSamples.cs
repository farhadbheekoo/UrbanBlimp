using System.Diagnostics;
using UrbanBlimp.Feed;

public class GetFeedServiceSamples
{
    public void Single()
    {
        var service = new GetFeedService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var feed = service.Execute("feedId");
        Debug.WriteLine(feed.FeedUrl);
    }

    public void Multiple()
    {
        var service = new GetFeedService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        foreach (var feed in service.Execute())
        {
            Debug.WriteLine(feed.FeedUrl);
        }
    }
}