using System;

namespace UrbanBlimp.Android
{
    public class DeleteRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(DeleteRegistrationRequest request, Action<DeleteRegistrationResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            //TODO: validate args
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + request.PushId);
			webRequest.Method = "Delete";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new DeleteRegistrationResponse()),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute();
        }
    }
}