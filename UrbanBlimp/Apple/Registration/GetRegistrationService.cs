using System;

namespace UrbanBlimp.Apple
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(GetRegistrationRequest request, Action<GetRegistrationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + request.DeviceToken);
			webRequest.Method = "Get";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                ReadFromResponse = stream => responseCallback(GetRegistrationResponseDeSerializer.DeSerialize(stream)),
                Request = webRequest,
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); 
        }
    }
}