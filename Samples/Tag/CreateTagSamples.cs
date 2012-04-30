using UrbanBlimp.Tag;

public class CreateTagSamples
{
    
    public void Multiple()
    {
        var service = new CreateTagService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        service.Execute("tag1");
    }
}