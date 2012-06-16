using System;

namespace UrbanBlimp.Android
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string pushId, Action<Registration> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Get";


            var asyncRequest = new AsyncRequest
            {
                Request = request,
                Callback = stream => callback(RegistrationDeSerializer.DeSerialize(stream)),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute();

        }
    }
}