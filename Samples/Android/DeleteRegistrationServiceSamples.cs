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
            service.Execute("AndroidPushId", () => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
        }
    }
}