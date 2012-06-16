using System.Diagnostics;
using UrbanBlimp.Tag;

public class RemoveTagFromDeviceServiceSamples
{

    public void Multiple()
    {
        var service = new RemoveTagFromDeviceService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        service.Execute("DeviceToken", "tag1", () => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
    }
}