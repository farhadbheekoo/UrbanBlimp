using System;
using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Tag
{
    public class GetTagService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(Action<List<string>> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/");
            request.Method = "GET";

            var asyncRequest = new AsyncRequest
            {
                Callback = stream => callback(TagDeSerializer.DeSerialize(stream).ToList()),
                Request = request,
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 

        }

        public void Execute(string deviceToken, Action<List<string>> callback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build(string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/", deviceToken));
            request.Method = "GET"; 
            
            var asyncRequest = new AsyncRequest
            {
                Callback = stream => callback(TagDeSerializer.DeSerialize(stream).ToList()),
                Request = request,
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 

        }
    }
}