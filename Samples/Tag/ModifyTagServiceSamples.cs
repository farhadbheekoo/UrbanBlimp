using System.Collections.Generic;
using System.Diagnostics;
using UrbanBlimp.Tag;

public class ModifyTagServiceSamples
{

    public void Multiple()
    {
        var service = new ModifyTagService
                          {
                              RequestBuilder = ServerRequestBuilder.Instance
                          };
        var tokens = new ModifyTagRequest
                         {
                             Tag = "tag1",
                             AddDevicePins = new List<string> {"AddDevicePin1", "AddDevicePin2"},
                             RemoveDevicePins = new List<string> {"RemoveDevicePin1", "RemoveDevicePin2"},
                             AddDeviceTokens = new List<string> {"AddDeviceToken1", "AddDeviceToken2"},
                             RemoveDeviceTokens = new List<string> {"RemoveDeviceToken1", "RemoveDeviceToken2"},
                             AddPushIds = new List<string> {"AddPushId1", "AddPushId2"},
                             RemovePushIds = new List<string> {"RemovePushId1", "RemovePushId2"}
                         };
        service.Execute(tokens, response => Debug.WriteLine("Success"),ExceptionHandler.Handle);
    }
}