using System.Collections.Generic;
using System.Diagnostics;
using UrbanBlimp.Apple;

namespace Apple
{
    public class AddRegistrationServiceSamples
    {

        public void Simple()
        {
            var service = new AddRegistrationService
                              {
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var registration = new Registration
                                   {
                                       Tags = new List<string> {"MyTag"},
                                       Alias = "MyAlias",
                                       Badge = 10
                                   };
            service.Execute("AppleDeviceId", registration, () => Debug.WriteLine("Success"), ExceptionHandler.Handle);
        }

    }
}