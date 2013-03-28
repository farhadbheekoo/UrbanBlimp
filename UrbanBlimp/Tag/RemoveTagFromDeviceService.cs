using System;

namespace UrbanBlimp.Tag
{
    public class RemoveTagFromDeviceService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(RemoveTagFromDeviceRequest request, Action<RemoveTagFromDeviceResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", request.DeviceToken, request.TagToRemove);
            var webRequest = RequestBuilder.Build(url);
			webRequest.Method = "DELETE";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                Request = webRequest,
                ReadFromResponse = o => responseCallback(new RemoveTagFromDeviceResponse()),
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }

    }
}