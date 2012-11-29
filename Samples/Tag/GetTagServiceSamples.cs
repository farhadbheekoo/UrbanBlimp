using System.Diagnostics;
using UrbanBlimp.Tag;

public class GetTagServiceSamples
{
    
    public void Multiple()
    {
        var service = new GetTagsService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        service.Execute(Callback, ExceptionHandler.Handle);
    }

    void Callback(GetTagsResponse response)
    {
        foreach (var tag in response.Tags)
        {
            Debug.WriteLine(tag);
        }
    }
}