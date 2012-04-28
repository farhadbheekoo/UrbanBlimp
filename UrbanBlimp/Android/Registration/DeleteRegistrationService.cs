namespace UrbanBlimp.Android
{
    public class DeleteRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public bool Execute(string pushId)
        {
            //TODO: validate args
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Delete";
            return request.DoRequest();
        }
    }
}