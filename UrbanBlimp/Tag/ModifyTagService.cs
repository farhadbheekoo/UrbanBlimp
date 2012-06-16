using System;

namespace UrbanBlimp.Tag
{
    public class ModifyTagService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string tag, Tokens tokens, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.ContentType = "application/json";
            request.Method = "POST";

            var asyncRequest = new AsyncRequest
            {
                WriteToRequestStream = stream => TokenSerializer.Serialize(tokens,stream),
                Request = request,
                Callback = o => callback(),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }
    }
}