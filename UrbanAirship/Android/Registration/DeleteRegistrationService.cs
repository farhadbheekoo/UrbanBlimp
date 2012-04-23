namespace UrbanBlimp.Android
{
    public class DeleteRegistrationService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public void Execute(string pushId)
        {
            //TODO: validate args
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Delete";
            using (request.GetResponse())
            {

            }

        }
    }
}