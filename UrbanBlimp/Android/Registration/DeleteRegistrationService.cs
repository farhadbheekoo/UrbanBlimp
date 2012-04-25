namespace UrbanBlimp.Android
{
    public class DeleteRegistrationService
    {
        public IRequestBuilder RequestBuilder ;

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