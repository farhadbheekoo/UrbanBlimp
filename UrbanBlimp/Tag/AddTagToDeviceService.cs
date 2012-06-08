using System;

namespace UrbanBlimp.Tag
{
    public class AddTagToDeviceService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string deviceToken, string tag, Action callback, Action<Exception> exceptionCallback)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", deviceToken, tag);
            var request = RequestBuilder.Build(url);
            request.Method = "PUT";
            request.DoRequest(b => callback(), exceptionCallback);
        }

    }
}