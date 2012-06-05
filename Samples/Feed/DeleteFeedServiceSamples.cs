using System.Diagnostics;
using UrbanBlimp.Feed;

public class DeleteFeedServiceSamples
{

    public void Simple()
    {
        var service = new DeleteFeedService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute("feedId", wasDeleted => Debug.WriteLine(wasDeleted),ExceptionHandler.Handle);
    }

}