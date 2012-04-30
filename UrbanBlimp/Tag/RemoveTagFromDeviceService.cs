namespace UrbanBlimp.Tag
{
    public class RemoveTagFromDeviceService
    {
        public IRequestBuilder RequestBuilder;

        public bool Execute(string deviceToken, string tagToRemove)
        {
            var url = string.Format("https://go.urbanairship.com/api/device_tokens/{0}/tags/{1}", deviceToken, tagToRemove);
            var request = RequestBuilder.Build(url);
            request.Method = "DELETE";
            return request.DoRequest();
        }

    }
}