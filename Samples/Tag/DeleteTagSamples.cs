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
        service.Execute("tag1", () => Debug.WriteLine("Deleted"), ExceptionHandler.Handle);
    }
}