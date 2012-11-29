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
        var request = new AddTagToDeviceRequest
                          {
                              DeviceToken = "DeviceToken",
                              Tag = "tag1"
                          };
        service.Execute(request, response => Debug.WriteLine("Success"), ExceptionHandler.Handle);
    }
}