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


            var asyncRequest = new AsyncRequest
            {
                PostData = postData,
                Request = request,
                Callback = o => callback(),
                ExceptionCallback = exceptionCallback,
            };

            asyncRequest.Execute(); ;

        }

        public void Execute(string deviceToken, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "PUT";
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