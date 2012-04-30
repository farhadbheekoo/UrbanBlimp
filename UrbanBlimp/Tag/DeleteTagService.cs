namespace UrbanBlimp.Tag
{
    public class DeleteTagService
    {
        public IRequestBuilder RequestBuilder;
        public bool Execute(string tag)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "DELETE";
            return request.DoRequest();
        }

    }
}