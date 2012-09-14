using System.Net;
using MonoTouch.CoreFoundation;
using UrbanBlimp;

namespace ClientRequestSamples
{
    public class IOSRequestBuilder : RequestBuilder
    {
        //Singleton for convenience. If use an IOC or prefer instance based this is not required
        public static IOSRequestBuilder Instance;

        static IOSRequestBuilder()
        {
            Instance = new IOSRequestBuilder();
        }


        public IOSRequestBuilder()
        {
            //NOTE: DO NOT USE YOUR MASTER CREDENTIALS HERE
            BuildApplicationCredentials = () => new NetworkCredential("ApplicationName", "ApplicationSecret");
            ConfigureRequest = request =>
                {
                    request.Proxy = CFNetwork.GetDefaultProxy();
                    //only a suggested timeout
                    request.Timeout = 30000;
                };
        }

    }
}