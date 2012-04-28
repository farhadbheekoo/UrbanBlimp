namespace UrbanBlimp.Apple
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public Registration Execute(string deviceToken)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "Get";

            return request.DoRequest(RegistrationDeSerializer.DeSerialize);

        }
    }
}