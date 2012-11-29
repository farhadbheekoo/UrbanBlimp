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
        var request = new RemoveTagFromDeviceRequest
                          {
                              DeviceToken = "DeviceToken",
                              TagToRemove = "tag1"
                          };
        service.Execute(request, response => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
    }
}