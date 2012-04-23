using System.Collections.Generic;
using UrbanBlimp.Android;

namespace Samples
{
    public class AddRegistrationServiceSamples
    {
        public void Simple()
        {
            var service = new AddRegistrationService
                              {
                                  RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                              };
            var registration = new NewRegistration
                                   {
                                       Tags = new List<string> {"MyTag"},
                                       Alias = "MyAlias"
                                   };
            service.Execute("AndroidPushId", registration);
        }
    }
}