using System;
using System.Linq;

namespace UrbanBlimp.Tag
{
    public class GetTagsService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(Action<GetTagsResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/");
            request.Method = "GET";

            var asyncRequest = new AsyncRequest
                                   {
                                       ReadFromResponse = stream => responseCallback(new GetTagsResponse { Tags = TagDeSerializer.DeSerialize(stream).ToList() }),
                                       Request = request,
                                       ExceptionCallback = exceptionCallback,
                                       RequestContentType = "application/json"
                                   };
            asyncRequest.Execute();

        }
    }
}