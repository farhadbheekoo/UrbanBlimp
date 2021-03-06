using System;

namespace UrbanBlimp.Feed
{
    public class GetAllFeedsService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(Action<GetAllFeedsResponse> responseCallback, Action<Exception> exceptionCallback)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/feeds/");
			request.Method = "Get";
			request.ContentType = "application/json";

            var asyncRequest = new AsyncRequest
            {
                ReadFromResponse = stream => responseCallback(FeedDeSerializer.DeSerializeMultiple(stream)),
                Request = request,
                ExceptionCallback = exceptionCallback,
            };
            asyncRequest.Execute(); 
        }

    }
}