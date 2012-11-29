using System;

namespace UrbanBlimp.Tag
{
    public class AddTagToDeviceService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(AddTagToDeviceRequest request, Action<AddTagToDeviceResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", request.DeviceToken, request.Tag);
            var webRequest = RequestBuilder.Build(url);
            webRequest.Method = "PUT";

            var asyncRequest = new AsyncRequest
            {
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new AddTagToDeviceResponse()),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }

    }
}