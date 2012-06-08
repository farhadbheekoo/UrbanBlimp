using System;

namespace UrbanBlimp.Apple
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string deviceToken, Action<Registration> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "Get";
            request.DoRequest(RegistrationDeSerializer.DeSerialize, callback, exceptionCallback);

        }
    }
}