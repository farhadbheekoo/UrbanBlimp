using System.Diagnostics;
using UrbanBlimp.Tag;

public class RemoveTagFromDeviceServiceSamples
{

    public void Multiple()
    {
        var service = new RemoveTagFromDeviceService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute("DeviceToken", "tag1",wasRemoved => Debug.WriteLine(wasRemoved),ExceptionHandler.Handle);
    }
}