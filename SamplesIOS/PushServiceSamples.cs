using System.Collections.Generic;
using UrbanBlimp.Apple;

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
                                       ExcludeTokens = new List<string> {"TokenToExclude"},
                                       DeviceTokens = new List<string> {"AppleDeviceId"},
                                       Aliases = new List<string> {"MyAlias"},
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "Alert 2",
                                                         Badge = "2",
                                                         Sound = "Sound1"
                                                     }
                                   };
            service.Execute(notification);
        }

    }
}