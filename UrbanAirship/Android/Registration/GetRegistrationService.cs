namespace UrbanBlimp.Android
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public Registration Execute(string pushId)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Get";
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                return RegistrationDeSerializer.DeSerialize(responseStream);
            }
        }
    }
}