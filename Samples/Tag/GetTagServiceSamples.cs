using System.Diagnostics;
using UrbanBlimp.Tag;

public class GetTagServiceSamples
{
    
    public void Multiple()
    {
        var service = new GetTagService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        foreach (var tag in service.Execute())
        {
            Debug.WriteLine(tag);
        }
    }
}