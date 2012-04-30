using UrbanBlimp.Tag;

public class RemoveTagFromDeviceServiceSamples
{

    public void Multiple()
    {
        var service = new RemoveTagFromDeviceService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute("DeviceToken", "tag1");
    }
}