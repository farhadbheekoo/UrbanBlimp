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
                                Password = "AirshipSecret"
                            };
                    }
            };
    }
}