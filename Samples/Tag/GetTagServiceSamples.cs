using System.Collections.Generic;
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
        service.Execute(Callback, ExceptionHandler.Handle);
    }

    void Callback(List<string> list)
    {
        foreach (var tag in list)
        {
            Debug.WriteLine(tag);
        }
    }
}