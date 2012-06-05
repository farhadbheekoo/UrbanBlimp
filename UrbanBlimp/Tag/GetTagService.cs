using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace UrbanBlimp.Tag
{
    public class GetTagService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(Action<List<string>> callback, Action<WebException> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/");
            request.Method = "GET";
            request.DoRequest(stream => TagDeSerializer.DeSerialize(stream).ToList(), callback, exceptionCallback);
        }

        public void Execute(string deviceToken, Action<List<string>> callback, Action<WebException> exceptionCallback)
        {
            var request = RequestBuilder.Build(string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/", deviceToken));
            request.Method = "GET";
            request.DoRequest(stream => TagDeSerializer.DeSerialize(stream).ToList(), callback, exceptionCallback);
        }
    }
}