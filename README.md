UrbanBlimp
==========

A dot net library to talk to Urban Ariship http://urbanairship.com/

Define a way of build an IRequestBuilder. This will be re-used on all future samples

    public static class CustomRequestBuilder
    {
        public static IRequestBuilder GetRequestBuilder()
        {
            return new RequestBuilder
                       {
                           NetworkCredential = new NetworkCredential
                                                   {
                                                       UserName = "AirshipApplicationKey",
                                                       Password = "AirshipSecret"
                                                   }
                       };
        }
    }
    
And a simple sample

    public void AppleAddRegistrationSample()
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