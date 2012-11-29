using System;

namespace UrbanBlimp.Android
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(AddRegistrationRequest registrationRequest, Action<AddRegistrationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + registrationRequest.PushId);
            request.Method = "PUT";
            var asyncRequest = new AsyncRequest
                {
                    Request = request,
                    ReadFromResponse = o => responseCallback(new AddRegistrationResponse()),
                    ExceptionCallback = exceptionCallback,
                    WriteToRequest = stream => stream.WriteToStream(registrationRequest.Serialize),
                    RequestContentType = "application/json"
                };
            asyncRequest.Execute();
        }

    }
}