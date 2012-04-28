namespace UrbanBlimp.Android
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(string pushId, NewRegistration registration)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            var postData = NewRegistrationSerializer.Serialize(registration);
            request.DoRequest(postData);
        }

        public void Execute(string pushId)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            request.DoRequest();
        }
    }
}