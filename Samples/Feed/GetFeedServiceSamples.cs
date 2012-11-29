using System.Diagnostics;
using UrbanBlimp.Feed;

public class GetFeedServiceSamples
{
    public void Simple()
    {
        var service = new GetFeedService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        var request = new GetFeedRequest
                          {
                              FeedId = "feedId"
                          };
        service.Execute(request, Callback, ExceptionHandler.Handle);
    }

    void Callback(GetFeedResponse response)
    {
        Debug.WriteLine(response.FeedUrl);
    }

}