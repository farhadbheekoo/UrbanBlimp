using System.Collections.Generic;
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
        service.Execute("feedId",Callback,ExceptionHandler.Handle);
    }

    void Callback(Feed feed)
    { 
        Debug.WriteLine(feed.FeedUrl);
    }

    public void Multiple()
    {
        var service = new GetFeedService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute(Callback, ExceptionHandler.Handle);

    }

    void Callback(List<Feed> feeds)
    {
        foreach (var feed in feeds)
        {
            Debug.WriteLine(feed.FeedUrl);
        }
    }
}