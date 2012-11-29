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
                    RequestBuilder = ServerRequestBuilder.Instance
                };
            var request = new GetRegistrationRequest {PushId = "AndroidPushId"};
            service.Execute(request, Callback, ExceptionHandler.Handle);
        }

        void Callback(GetRegistrationResponse response)
        {
            Debug.WriteLine(response.Active);
            Debug.WriteLine(response.Alias);
            Debug.WriteLine(response.Created);
            Debug.WriteLine(string.Join(" ", response.Tags));
        }
    }
}