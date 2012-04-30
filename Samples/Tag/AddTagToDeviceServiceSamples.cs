using UrbanBlimp.Tag;

public class AddTagToDeviceServiceSamples
{
    
    public void Multiple()
    {
        var service = new AddTagToDeviceService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute("DeviceToken", "tag1");
    }
}