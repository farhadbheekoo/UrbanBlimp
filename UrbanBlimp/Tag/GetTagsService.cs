using System.Collections.Generic;
using System.Linq;

namespace UrbanBlimp.Tags
{
    public class GetTagsService
    {
        public IRequestBuilder RequestBuilder;

        public List<string> Execute()
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/");
            request.Method = "GET";
            return request.DoRequest(stream => TagDeSerializer.DeSerialize(stream).ToList());
        }

        public List<string> Execute(string deviceToken)
        {
            var request = RequestBuilder.Build(string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/", deviceToken));
            request.Method = "GET";
            return request.DoRequest(stream => TagDeSerializer.DeSerialize(stream).ToList());
        }
    }
}