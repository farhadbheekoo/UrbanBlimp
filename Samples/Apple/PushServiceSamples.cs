using System.Collections.Generic;
using System.Diagnostics;
using UrbanBlimp.Apple;

namespace Apple
{
    public class PushServiceSamples
    {

        public void Simple()
        {
            var service = new PushService
                              {
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var notification = new PushNotificationRequest
                                   {
                                       Tags = new List<string> {"MyTag"},
                                       ExcludeTokens = new List<string> {"TokenToExclude"},
                                       DeviceTokens = new List<string> {"AppleDeviceId"},
                                       Aliases = new List<string> {"MyAlias"},
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "Alert 2",
                                                         Badge = Badge.SetTo(2),
                                                         Sound = "Sound1"
                                                     }
                                   };
            service.Execute(notification, response => Debug.WriteLine("Success"),ExceptionHandler.Handle);
        }

    }
}