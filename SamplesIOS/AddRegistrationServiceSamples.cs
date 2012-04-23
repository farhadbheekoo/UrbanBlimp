using System.Collections.Generic;
using Samples;
using UrbanBlimp.Apple;

public class AddRegistrationServiceSamples
{

    public void Simple()
    {
        var service = new AddRegistrationService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var registration = new Registration
                               {
                                   Tags = new List<string> {"MyTag"},
                                   Alias = "MyAlias",
                                   Badge = 10
                               };
        service.Execute("AppleDeviceId", registration);
    }

}