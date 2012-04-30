namespace UrbanBlimp.Tag
{
    public class ModifyTagService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string tag, Tokens tokens)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/tags/" + tag);
            request.Method = "POST";
            var postData = TokenSerializer.Serialize(tokens);
            request.DoRequest(postData);
        }
    }
}