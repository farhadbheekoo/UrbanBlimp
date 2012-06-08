using System;

namespace UrbanBlimp.Apple
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string deviceToken, Registration registration, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "PUT";
            var postData = RegistrationSerializer.Serialize(registration);
            request.DoRequest(postData, b => callback(), exceptionCallback);
        }

        public void Execute(string deviceToken, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "PUT";
            request.DoRequest(b => callback(), exceptionCallback);
        }
    }
}