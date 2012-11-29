using System.Collections.Generic;
using System.Diagnostics;
using UrbanBlimp.Android;

namespace Android
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
                                       PushIds = new List<string> {"AndroidPushId"},
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "Alert 2"
                                                     }
                                   };
            service.Execute(notification,response => Debug.WriteLine("Success"),ExceptionHandler.Handle);
        }

    }
}