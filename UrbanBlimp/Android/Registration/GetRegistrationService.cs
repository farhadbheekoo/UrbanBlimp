
namespace UrbanBlimp.Android
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder;

        public Registration Execute(string pushId)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Get";
            return request.DoRequest(RegistrationDeSerializer.DeSerialize);
        }
    }
}