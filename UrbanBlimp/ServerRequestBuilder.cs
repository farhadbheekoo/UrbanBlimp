using System;
using System.Net;

namespace UrbanBlimp
{
    public class RequestBuilder :IRequestBuilder
    {

        public Func<NetworkCredential> BuildApplicationMasterCredentials { get; set; }

        public WebRequest Build(string url)
        {
            var request = WebRequest.Create(url);
            request.Credentials = BuildApplicationMasterCredentials();
            request.PreAuthenticate = true;
            return request;
        }
    }

    public interface IRequestBuilder
    {
        Func<NetworkCredential> BuildApplicationMasterCredentials { get; set; }
        WebRequest Build(string url);
    }



}