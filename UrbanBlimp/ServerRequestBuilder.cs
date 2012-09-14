using System;
using System.Net;

namespace UrbanBlimp
{
    public class RequestBuilder :IRequestBuilder
    {
        public Func<NetworkCredential> BuildApplicationMasterCredentials;
        public Action<WebRequest> ConfigureRequest;


        public HttpWebRequest Build(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            if (BuildApplicationMasterCredentials == null)
            {
                throw new Exception("You need to define a 'RequestBuilder.BuildApplicationMasterCredentials'.");
            }
            request.Credentials = BuildApplicationMasterCredentials();
            request.PreAuthenticate = true;
            if (ConfigureRequest != null)
            {
                ConfigureRequest(request);
            }
            return request;
        }

    }
}