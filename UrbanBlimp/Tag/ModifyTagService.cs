using System;

namespace UrbanBlimp.Tag
{
    public class ModifyTagService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(ModifyTagRequest request, Action<ModifyTagResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + request.Tag);
            webRequest.Method = "POST";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequest = stream => stream.WriteToStream(request.Serialize),
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new ModifyTagResponse()),
                ExceptionCallback = exceptionCallback,
                RequestContentType = "application/json"
            };
            asyncRequest.Execute(); 
        }
    }
}