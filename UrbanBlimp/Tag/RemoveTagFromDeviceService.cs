using System;
using System.Net;

namespace UrbanBlimp.Tag
{
    public class RemoveTagFromDeviceService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string deviceToken, string tagToRemove, Action<bool> callback, Action<WebException> exceptionCallback)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", deviceToken, tagToRemove);
            var request = RequestBuilder.Build(url);
            request.Method = "DELETE";
            request.DoRequest(callback, exceptionCallback);
        }

    }
}