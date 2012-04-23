using UrbanBlimp;

public static class RequestBuilderHelper
{
    public static IRequestBuilder Build()
    {
        return new RequestBuilder
                   {
                       NetworkCredential = RemoteSettings.ApplicationMasterCredential
                   };
    }
}