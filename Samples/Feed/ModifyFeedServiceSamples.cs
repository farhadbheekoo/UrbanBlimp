using System.Diagnostics;
using UrbanBlimp.Feed;

public class ModifyFeedServiceSamples
{

    public void Simple()
    {
        var service = new ModifyFeedService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        var request = new ModifyFeedRequest
                          {
                              FeedId = "feedId",
                              FeedUrl = "http://example.com/atom.xml",
                              Template = new Template
                                             {
                                                 FeedPayload = new FeedPayload
                                                                   {
                                                                       Badge = 1,
                                                                       Sound = "cat.caf",
                                                                       Alert = "New item from some place! {{ title }}"
                                                                   }
                                             },
                              BroadCast = true
                          };
        service.Execute(request, response => Debug.WriteLine("Success"), ExceptionHandler.Handle);
    }

}