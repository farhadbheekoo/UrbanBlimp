using System;

namespace UrbanBlimp.Feed
{
    public class CreateFeedService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(CreateFeedRequest request, Action<CreateFeedResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var webRequest = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
            webRequest.Method = "POST";

            var asyncRequest = new AsyncRequest
                                   {
                                       WriteToRequest = stream => stream.WriteToStream(request.Serialize),
                                       Request = webRequest,
                                       ReadFromResponse = stream => responseCallback(CreateFeedResponseDeSerializer.DeSerialize(stream)),
                                       ExceptionCallback = exceptionCallback,
                                       RequestContentType = "application/json"
                                   };

            asyncRequest.Execute();

        }
    }
}