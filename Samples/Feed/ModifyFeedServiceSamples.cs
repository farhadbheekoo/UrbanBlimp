using System.Diagnostics;
using UrbanBlimp.Feed;

public class ModifyFeedServiceSamples
{

    public void Simple()
    {
        var service = new ModifyFeedService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var updateFeed = new UpdateFeed
                             {
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
        service.Execute("feedId", updateFeed,() => Debug.WriteLine("Success"), ExceptionHandler.Handle);
    }

}