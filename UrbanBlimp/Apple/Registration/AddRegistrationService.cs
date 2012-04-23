using System.Text;

namespace UrbanBlimp.Apple
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public void Execute(string deviceToken, Registration registration)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
            request.Method = "PUT";
            if (registration != null)
            {
                var postData = RegistrationSerializer.Serialize(registration);
                var byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            using (request.GetResponse())
            {

            }

        }
    }
}