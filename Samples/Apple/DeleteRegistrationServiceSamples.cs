using System.Diagnostics;
using UrbanBlimp.Apple;

namespace Apple
{
    public class DeleteRegistrationServiceSamples
    {
        public void Simple()
        {
            var service = new DeleteRegistrationService
                              {
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var request = new DeleteRegistrationRequest
                              {
                                  DeviceToken = "ApplePushId"
                              };
            service.Execute(request, response => Debug.WriteLine("Success"), ExceptionHandler.Handle);
        }
    }
}