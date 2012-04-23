using System.Diagnostics;
using UrbanBlimp.Android;

public class GetRegistrationServiceSamples
{
    public void Simple()
    {
        var service = new GetRegistrationService
                          {
                              RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                          };
        var registration = service.Execute("AndroidPushId");
        Debug.WriteLine(registration.Active);
        Debug.WriteLine(registration.Alias);
        Debug.WriteLine(registration.Created);
        Debug.WriteLine(string.Join(" ", registration.Tags));
    }
}