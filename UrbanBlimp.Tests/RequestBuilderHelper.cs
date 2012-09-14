using UrbanBlimp;

public static class RequestBuilderHelper
{
    public static IRequestBuilder Build()
    {
        return new RequestBuilder
                   {
                       BuildApplicationMasterCredentials = () => { return RemoteSettings.ApplicationMasterCredential; }
                   };
    }
}