namespace UrbanBlimp.Apple
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string deviceToken, Registration registration)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "PUT";
            var postData = RegistrationSerializer.Serialize(registration);
            request.DoRequest(postData);
        }

        public void Execute(string deviceToken)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "PUT";
            request.DoRequest();
        }
    }
}