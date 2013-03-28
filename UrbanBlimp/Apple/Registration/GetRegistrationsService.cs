using System;

namespace UrbanBlimp.Apple
{
    public class GetRegistrationsService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(GetRegistrationsRequest request, Action<GetRegistrationsResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/?Limit={0}&start={1}", request.Limit, request.Start);
            var webRequest = RequestBuilder.Build(url);
			webRequest.Method = "GET";
			webRequest.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
                {
                    ReadFromResponse = stream => responseCallback(GetRegistrationsResponseDeSerializer.DeSerialize(stream)),
                    Request = webRequest,
                    ExceptionCallback = exceptionCallback,
                };
            asyncRequest.Execute();
        }
    }
}