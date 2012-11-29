using System;

namespace UrbanBlimp.Tag
{
    public class CreateTagService
    {
        public IRequestBuilder RequestBuilder;
        public void Execute(CreateTagRequest request, Action<CreateTagResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + request.Tag);
            webRequest.Method = "PUT";
            var asyncRequest = new AsyncRequest
            {
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new CreateTagResponse()),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }
    }
}