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
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var request = new GetRegistrationRequest
                                             {
                                                 DeviceToken = "ApplePushId"
                                             };
            service.Execute(request, Callback, ExceptionHandler.Handle);
        }

        void Callback(GetRegistrationResponse response)
        {
            Debug.WriteLine(response.Badge);
            Debug.WriteLine(response.Alias);
            Debug.WriteLine(response.QuietTime);
            Debug.WriteLine(response.TimeZone);
            Debug.WriteLine(string.Join(" ", response.Tags));
        }
    }
}