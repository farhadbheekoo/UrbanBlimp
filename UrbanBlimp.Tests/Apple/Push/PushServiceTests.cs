using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class PushServiceTests
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
                    DeviceTokens = new List<string> {RemoteSettings.AppleDeviceId},
                    Payload = new PushPayload
                        {
                            Alert = "Alert 2"
                        }
                };

            var helper = new AsyncTestHelper();
            service.Execute(pushNotification, helper.Callback, helper.HandleException);
            helper.Wait();
        }

        [Test]
        [Ignore]
        public void ToTag()
        {
            var service = new PushService
                {
                    RequestBuilder = RequestBuilderHelper.Build()
                };
            var pushNotification = new PushNotification
                {
                    Tags = new List<string> {"africa"},
                    Payload = new PushPayload
                        {
                            Alert = "Alert 2"
                        }
                };

            var helper = new AsyncTestHelper();
            service.Execute(pushNotification, helper.Callback, helper.HandleException);
            helper.Wait();
        }
    }
}