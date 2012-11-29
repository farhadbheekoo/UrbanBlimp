using System.Diagnostics;
using UrbanBlimp.Tag;

public class DeleteTagSamples
{
    
    public void Multiple()
    {
        var service = new DeleteTagService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        var request = new DeleteTagRequest
                          {
                              Tag = "tag1"
                          };
        service.Execute(request, response => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
    }
}