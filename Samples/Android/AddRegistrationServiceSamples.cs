using System.Collections.Generic;
using System.Diagnostics;
using UrbanBlimp.Android;

namespace Android
{
    public class AddRegistrationServiceSamples
    {
        public void Simple()
        {
            var service = new AddRegistrationService
                              {
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var registration = new AddRegistrationRequest
                                   {
                                       PushId = "AndroidPushId",
                                       Tags = new List<string> {"MyTag"},
                                       Alias = "MyAlias"
                                   };
            service.Execute(registration, response => Debug.WriteLine("Success"), ExceptionHandler.Handle);
        }
    }
}