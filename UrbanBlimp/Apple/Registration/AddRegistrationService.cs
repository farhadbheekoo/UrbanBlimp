using System;

namespace UrbanBlimp.Apple
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(AddRegistrationRequest request, Action<AddRegistrationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + request.DeviceToken);
            webRequest.Method = "PUT";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequest = stream => stream.WriteToStream(request.Serialize),
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new AddRegistrationResponse()),
                ExceptionCallback = exceptionCallback,
                    RequestContentType = "application/json"
            };

            asyncRequest.Execute();
        }

    }
}