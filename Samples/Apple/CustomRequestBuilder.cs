using System.Net;
using UrbanBlimp;

namespace Apple
{

    public static class CustomRequestBuilder
    {
        public static IRequestBuilder GetRequestBuilder()
        {
            return new RequestBuilder
                       {
                           NetworkCredential = new NetworkCredential
                                                   {
                                                       UserName = "AirshipApplicationKey",
                                                       Password = "AirshipSecret"
                                                   }
                       };
        }
    }
}