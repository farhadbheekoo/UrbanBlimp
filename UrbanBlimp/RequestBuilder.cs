using System.Net;

namespace UrbanBlimp
{
    public class RequestBuilder : IRequestBuilder
    {
        public NetworkCredential NetworkCredential;
        public WebRequest Build(string url)
        {
            var request = WebRequest.Create(url);
            request.Credentials = NetworkCredential;
            request.PreAuthenticate = true;
            return request;
        }
    }

    public interface IRequestBuilder
    {
        WebRequest Build(string url);
    }
}