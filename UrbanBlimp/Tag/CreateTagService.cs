using System;

namespace UrbanBlimp.Tag
{
    public class CreateTagService
    {
        public IRequestBuilder RequestBuilder;
        public void Execute(string tag, Action callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "PUT";
            request.DoRequest(b => callback(), exceptionCallback);
        }
    }
}