using System;
using System.Linq;

namespace UrbanBlimp.Tag
{
    public class GetTagsForDeviceService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(GetTagsForDeviceRequest request, Action<GetTagsForDeviceResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build(string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/", request.DeviceToken));
			webRequest.Method = "GET";
			webRequest.ContentType = "application/json";
            
            var asyncRequest = new AsyncRequest
                                   {
                                       ReadFromResponse = stream => responseCallback(new GetTagsForDeviceResponse { Tags = TagDeSerializer.DeSerialize(stream).ToList() }),
                                       Request = webRequest,
                                       ExceptionCallback = exceptionCallback,
                                   };
            asyncRequest.Execute(); 

        }
    }
}