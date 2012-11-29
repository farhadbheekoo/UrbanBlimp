using System.Diagnostics;
using UrbanBlimp.Feed;

public class CreateFeedServiceSamples
{

    public void Simple()
    {
        var service = new CreateFeedService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        var notification = new CreateFeedRequest
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
        service.Execute(notification,Callback,ExceptionHandler.Handle);
    }

    void Callback(CreateFeedResponse response)
    {
        Debug.WriteLine(response);
    }
}