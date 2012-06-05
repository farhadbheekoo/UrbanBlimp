using System;
using System.Net;

namespace UrbanBlimp.Tag
{
    public class CreateTagService
    {
        public IRequestBuilder RequestBuilder;
        public void Execute(string tag, Action callback, Action<WebException> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "PUT";
            request.DoRequest(b => callback(), exceptionCallback);
        }
    }
}