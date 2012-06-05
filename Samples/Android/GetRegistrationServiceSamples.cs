using System.Diagnostics;
using UrbanBlimp.Android;

namespace Android
{
    public class GetRegistrationServiceSamples
    {
        public void Simple()
        {
            var service = new GetRegistrationService
                {
                    RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                };
            service.Execute("AndroidPushId", Callback, ExceptionHandler.Handle);
        }

        void Callback(Registration registration)
        {
            Debug.WriteLine(registration.Active);
            Debug.WriteLine(registration.Alias);
            Debug.WriteLine(registration.Created);
            Debug.WriteLine(string.Join(" ", registration.Tags));
        }
    }
}