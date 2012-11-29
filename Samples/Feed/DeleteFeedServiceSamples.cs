using System.Diagnostics;
using UrbanBlimp.Feed;

public class DeleteFeedServiceSamples
{

    public void Simple()
    {
        var service = new DeleteFeedService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        var request = new DeleteFeedRequest
                          {
                              FeedId = "feedId"
                          };
        service.Execute(request, response => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
    }

}