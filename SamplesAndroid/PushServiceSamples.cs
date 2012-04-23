using System.Collections.Generic;
using UrbanBlimp.Android;

namespace Samples
{
    public class PushServiceSamples
    {

        public void Simple()
        {
            var service = new PushService
                              {
                                  RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                              };
            var notification = new PushNotification
                                   {
                                       Tags = new List<string> {"MyTag"},
                                       PushIds = new List<string> {"AndroidPushId"},
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "Alert 2"
                                                     }
                                   };
            service.Execute(notification);
        }

    }
}