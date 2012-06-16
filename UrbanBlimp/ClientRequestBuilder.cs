using System;
using System.Net;

namespace UrbanBlimp
{
    public class RequestBuilder : IRequestBuilder
    {

        public Func<NetworkCredential> BuildApplicationCredentials;
        public Action<WebRequest> ConfigureRequest;

        public WebRequest Build(string url)
        {
            var request = WebRequest.Create(url); 
            if (BuildApplicationCredentials == null)
            {
                throw new Exception("You need to define a 'RequestBuilder.BuildApplicationCredentials'.");
            }
            request.Credentials = BuildApplicationCredentials();
            request.PreAuthenticate = true;
            if (ConfigureRequest != null)
            {
                ConfigureRequest(request);
            }
            return request;
        }

        
    }

}