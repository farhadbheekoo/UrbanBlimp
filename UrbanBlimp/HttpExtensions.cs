using System;
using System.IO;
using System.Net;
using System.Text;

namespace UrbanBlimp
{
    static class HttpExtensions
    {
        public static bool DoRequest(this WebRequest request, string postData)
        {
            request.WriteToRequest(postData);

            return request.DoRequest();
        }

        public static T DoRequest<T>(this WebRequest request, string postData, Func<Stream, T> action)
        {
            request.WriteToRequest(postData);

            return request.DoRequest(action);
        }

        static void WriteToRequest(this WebRequest request, string postData)
        {
            var byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }
        }

        public static bool DoRequest(this WebRequest webRequest)
        {
            try
            {
                using (webRequest.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException webException)
            {
                if (webException.StatusCode() == HttpStatusCode.NotFound)
                {
                    return false;
                }
                throw;
            }
        }

        public static T DoRequest<T>(this WebRequest webRequest, Func<Stream, T> action)
        {
            try
            {
                using (var response = webRequest.GetResponse())
                {

                    using (var responseStream = response.GetResponseStream())
                    {
                        return action(responseStream);
                    }
                }
            }
            catch (WebException webException)
            {
                if (webException.StatusCode() == HttpStatusCode.NotFound)
                {
                    return default(T);
                }
                throw;
            }
        }

        static HttpStatusCode StatusCode(this WebException webException)
        {
            var httpWebResponse = ((HttpWebResponse) (webException.Response));
            return httpWebResponse.StatusCode;
        }
    }
}