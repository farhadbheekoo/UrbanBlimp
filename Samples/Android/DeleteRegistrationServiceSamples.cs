using System.Diagnostics;
using UrbanBlimp.Android;

namespace Android
{
    public class DeleteRegistrationServiceSamples
    {
        public void Simple()
        {
            var service = new DeleteRegistrationService
                              {
                                  RequestBuilder = ServerRequestBuilder.Instance
                              };
            var request = new DeleteRegistrationRequest {PushId = "AndroidPushId"};
            service.Execute(request, response => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
        }
    }
}