using System.Text;

namespace UrbanBlimp.Android
{
    public class AddRegistrationService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public void Execute(string pushId, NewRegistration registration)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "PUT";
            if (registration != null)
            {
                var postData = NewRegistrationSerializer.Serialize(registration);
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