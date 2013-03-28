using System;

namespace UrbanBlimp.Android
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(GetRegistrationRequest request, Action<GetRegistrationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + request.PushId);
			webRequest.Method = "Get";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                Request = webRequest,
                ReadFromResponse = stream => responseCallback(GetRegistrationResponseDeSerializer.DeSerialize(stream)),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute();

        }
    }
}