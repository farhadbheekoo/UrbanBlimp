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
                                  RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                              };
            service.Execute("ApplePushId",() => Debug.WriteLine("Success"),ExceptionHandler.Handle);
        }
    }
}