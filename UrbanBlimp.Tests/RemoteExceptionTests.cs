using System;
using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp;
using UrbanBlimp.Apple;

[TestFixture]
public class RemoteExceptionTests
{

    [Test]
#if(RELEASE)
    [Ignore]
#endif
    public void Simple()
    {
        var service = new PushService
            {
                RequestBuilder = RequestBuilderHelper.Build()
            };
        var request = new PushNotificationRequest
            {
                DeviceTokens = new List<string>
                    {
                        "BadToken"
                    },
                Payload = new PushPayload
                    {
                        Alert = "Alert"
                    },
            };

        Exception exception = null;
        try
        {

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(request, respone => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
        catch (Exception e)
        {
            exception = e;
        }

        var remoteException = exception as RemoteException;
        Assert.IsNotNull(remoteException);
        Assert.AreEqual("{\"error_code\": 40001, \"details\": {\"device_tokens.0.device_token\": [\"device_token contains an invalid device token: BADTOKEN\"]}, \"error\": \"Data validation error\"}", remoteException.Message);
    }

}