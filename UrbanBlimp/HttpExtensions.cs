using System.Net;

namespace UrbanBlimp
{
    static class HttpExtensions
    {
        public static bool IsNotFound(this WebException webException)
        {
            //TODO: unit test to hit this
            if (webException.Response == null)
            {
                return false;
            }
            var httpWebResponse = (HttpWebResponse)webException.Response;
            return httpWebResponse.StatusCode == HttpStatusCode.NotFound;
        }
    }
}