using System.Net;
using UrbanBlimp;

    public static class CustomRequestBuilder
    {
        public static IRequestBuilder GetRequestBuilder()
        {
            return new RequestBuilder
            {
                BuildApplicationMasterCredentials = () =>
                    {
                        return new NetworkCredential
                            {
                                UserName = "AirshipApplicationKey",
                                Password = "AirshipApplicationMasterSecret"
                            };
                    }
            };
        }
    }
//public static class CustomRequestBuilder
//{
//    public static IRequestBuilder GetRequestBuilder()
//    {
//        return new RequestBuilder
//        {
//            BuildApplicationCredentials = () =>
//            {
//                return new NetworkCredential
//                {
//                    UserName = "AirshipApplicationKey",
//                    Password = "AirshipApplicationSecret"
//                };
//            }
//        };
//    }
//}