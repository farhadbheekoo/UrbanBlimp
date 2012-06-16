using System;

namespace UrbanBlimp.Android
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string pushId, NewRegistration registration, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var asyncRequest = new AsyncRequest
                {
                    Request = request,
                    Callback = o => callback(),
                    ExceptionCallback = exceptionCallback,
                    WriteToRequestStream = stream => registration.Serialize(stream)
                };
            asyncRequest.Execute();
        }

        public void Execute(string pushId, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var asyncRequest = new AsyncRequest
                {
                    Request = request,
                    Callback = o => callback(),
                    ExceptionCallback = exceptionCallback,
                };
            asyncRequest.Execute();
        }
    }
}