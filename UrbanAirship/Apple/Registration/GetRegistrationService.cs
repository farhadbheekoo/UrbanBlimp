namespace UrbanBlimp.Apple
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public Registration Execute(string deviceToken)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "Get";
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                return RegistrationDeSerializer.DeSerialize(responseStream);
            }
        }
    }
}