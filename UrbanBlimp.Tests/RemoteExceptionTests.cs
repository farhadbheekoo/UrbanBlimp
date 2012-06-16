using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp;
using UrbanBlimp.Apple;

[TestFixture]
public class RemoteExceptionTests
{

    [Test]
    [Ignore]
    public void Simple()
    {
        var service = new PushService
            {
                RequestBuilder = RequestBuilderHelper.Build()
            };
        var pushNotification = new PushNotification
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

        
            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(pushNotification, () => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();

        var remoteException = asyncTestHelper.Exception as RemoteException;
        Assert.IsNotNull(remoteException);
        Assert.AreEqual("{\"error_code\": 40001, \"details\": {\"device_tokens.0.device_token\": [\"device_token contains an invalid device token: BADTOKEN\"]}, \"error\": \"Data validation error\"}", remoteException.Message);
    }

}