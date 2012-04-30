using System.Diagnostics;
using UrbanBlimp.Apple;

namespace Apple
{
    public class GetRegistrationServiceSamples
    {
        public void Tags()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                              };
            var registration = service.Execute("ApplePushId");
            Debug.WriteLine(registration.Badge);
            Debug.WriteLine(registration.Alias);
            Debug.WriteLine(registration.QuietTime);
            Debug.WriteLine(registration.TimeZone);
            Debug.WriteLine(string.Join(" ", registration.Tags));
        }
    }
}