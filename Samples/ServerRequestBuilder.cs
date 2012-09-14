    using System.Net;
    using UrbanBlimp;

    public class ServerRequestBuilder : RequestBuilder
    {
        //Singleton for convenience. If use an IOC or prefer instance based this is not required
        public static ServerRequestBuilder Instance;

        static ServerRequestBuilder()
        {
            Instance = new ServerRequestBuilder();
        }


        public ServerRequestBuilder()
        {
            //NOTE: Be careful about managing your master secret. Consider reading it from an encrypted setting on the server
            BuildApplicationMasterCredentials = () => new NetworkCredential("ApplicationName", "ApplicationMasterSecret");
            ConfigureRequest = request =>
            {
                //TODO: configure proxy if necessary
                //request.Proxy = XXX

                //only a suggested timeout
                request.Timeout = 30000;
            };
        }

    }