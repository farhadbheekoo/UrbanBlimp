using System;

namespace UrbanBlimp.Apple
{
    public class DeleteRegistrationService
    {

        public IRequestBuilder RequestBuilder;

        public void Execute(string deviceToken, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "Delete";
            var asyncRequest = new AsyncRequest
            {
                Request = request,
                ReadFromResponse = o => callback(),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute();
        }
    }
}