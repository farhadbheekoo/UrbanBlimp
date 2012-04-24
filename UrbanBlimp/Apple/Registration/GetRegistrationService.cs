using System;
using System.Net;

namespace UrbanBlimp.Apple
{
    public class GetRegistrationService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public Registration Execute(string deviceToken)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/device_tokens/" + deviceToken);
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