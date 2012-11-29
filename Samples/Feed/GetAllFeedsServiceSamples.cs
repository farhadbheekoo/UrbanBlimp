using System.Diagnostics;
using UrbanBlimp.Feed;

public class GetAllFeedsServiceSamples
{
    public void Multiple()
    {
        var service = new GetAllFeedsService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        service.Execute(Callback, ExceptionHandler.Handle);

    }

    void Callback(GetAllFeedsResponse response)
    {
        foreach (var feed in response.Feeds)
        {
            Debug.WriteLine(feed.FeedUrl);
        }
    }
}