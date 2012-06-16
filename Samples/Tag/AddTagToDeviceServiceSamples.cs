using System.Diagnostics;
using UrbanBlimp.Tag;

public class AddTagToDeviceServiceSamples
{
    
    public void Multiple()
    {
        var service = new AddTagToDeviceService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        service.Execute("DeviceToken", "tag1",() => Debug.WriteLine("Success"),ExceptionHandler.Handle);
    }
}