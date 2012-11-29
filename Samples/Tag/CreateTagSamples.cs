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
        var request = new CreateTagRequest {Tag = "tag1"};
        service.Execute(request, response => Debug.WriteLine("Success"), ExceptionHandler.Handle);
    }
}