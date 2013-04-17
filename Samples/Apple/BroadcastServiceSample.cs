using System.Collections.Generic;
using System.Diagnostics;
using UrbanBlimp.Apple;

namespace Apple
{
  public class BroadcastServiceSample
  {
        public void Simple()
        {
            var service = new BroadcastService
                              {
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var notification = new BroadcastNotificationRequest
                                   {
                                       ExcludeTokens = new List<string> {"TokenToExclude"},
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "Alert 2",
                                                         Badge = Badge.Increment()
                                                     }
                                   };
            service.Execute(notification, response => Debug.WriteLine("Success"),ExceptionHandler.Handle);
        }
  }
}