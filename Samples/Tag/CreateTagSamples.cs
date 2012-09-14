using System.Diagnostics;
using UrbanBlimp.Tag;

public class CreateTagSamples
{
    
    public void Multiple()
    {
        var service = new CreateTagService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        service.Execute("tag1", () => Debug.WriteLine("Success"), ExceptionHandler.Handle);
    }
}