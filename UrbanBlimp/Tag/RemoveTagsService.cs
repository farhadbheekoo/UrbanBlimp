namespace UrbanBlimp.Tags
{
    public class RemoveTagsService
    {
        public IRequestBuilder RequestBuilder;
        public bool Execute(string tag)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "DELETE";
           return request.DoRequest();
        }

        public bool Execute(string deviceTokenToRemoveTagFrom, string tagToRemove)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", deviceTokenToRemoveTagFrom, tagToRemove);
            var request = RequestBuilder.Build(url);
            request.Method = "DELETE";
            return request.DoRequest();
        }

    }
}