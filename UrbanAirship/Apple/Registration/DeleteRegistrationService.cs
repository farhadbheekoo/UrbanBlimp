namespace UrbanBlimp.Apple
{
    public class DeleteRegistrationService
    {

        public IRequestBuilder RequestBuilder { get; set; }

        public void Execute(string deviceToken)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "Delete";
            using (request.GetResponse())
            {

            }

        }
    }
}