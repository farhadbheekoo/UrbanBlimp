using System;
using System.Net;

namespace UrbanBlimp
{
    public class RequestBuilder : IRequestBuilder
    {

        public Func<NetworkCredential> BuildApplicationCredentials { get; set; }

        public WebRequest Build(string url)
        {
            var request = WebRequest.Create(url);
            request.Credentials = BuildApplicationCredentials();
            request.PreAuthenticate = true;
            return request;
        }
    }

    public interface IRequestBuilder
    {
        Func<NetworkCredential> BuildApplicationCredentials { get; set; }
        WebRequest Build(string url);
    }



}