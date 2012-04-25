using System.Net;

namespace UrbanBlimp.Android
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder ;

        public Registration Execute(string pushId)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/apids/" + pushId);
            request.Method = "Get";
            try
            {
                using (var response = request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                {
                    return RegistrationDeSerializer.DeSerialize(responseStream);
                }
            }
            catch (WebException webException)
            {
                var httpStatusCode = ((HttpWebResponse) (webException.Response)).StatusCode;
                if (httpStatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }
    }
}