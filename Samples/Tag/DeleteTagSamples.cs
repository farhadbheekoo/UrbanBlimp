using UrbanBlimp.Tag;

public class DeleteTagSamples
{
    
    public void Multiple()
    {
        var service = new DeleteTagService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute("tag1");
    }
}