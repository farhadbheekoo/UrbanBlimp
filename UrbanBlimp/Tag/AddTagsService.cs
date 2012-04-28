namespace UrbanBlimp.Tags
{
    public class AddTagsService
    {
        public IRequestBuilder RequestBuilder;
        public void Execute(string tag)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "PUT";
            request.DoRequest();
        }

        public void Execute(string tag, string deviceToken)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", deviceToken, tag);
            var request = RequestBuilder.Build(url);
            request.Method = "PUT";
            request.DoRequest();
        }

    }
}