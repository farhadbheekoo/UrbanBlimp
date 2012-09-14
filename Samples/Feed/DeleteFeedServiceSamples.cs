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
        service.Execute("feedId", () => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
    }

}