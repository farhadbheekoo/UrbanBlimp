using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class PushServiceTests
    {

        [Test]
        public void Simple()
        {
            var service = new PushService
                {
                    RequestBuilder = RequestBuilderHelper.Build()
                };
            var pushNotification = new PushNotificationRequest
                {
                    DeviceTokens = new List<string>
                        {
                            RemoteSettings.AppleDeviceId
                        },
                    Payload = new PushPayload
                        {
                            Alert = "Alert"
                        },
                    CustomData = new Dictionary<string, string>
                        {
                         {"Key", "Value"}
                        }
                };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(pushNotification, response => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }

        [Test]
        public void ToTag()
        {
            var service = new PushService
                {
                    RequestBuilder = RequestBuilderHelper.Build()
                };
            var pushNotification = new PushNotificationRequest
                {
                    Tags = new List<string> { "africa" },
                    Payload = new PushPayload
                        {
                            Alert = "Alert 2"
                        }
                };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(pushNotification, response => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}