using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Android;

namespace UrbanBlimp.Tests.Android
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
                    PushIds = new List<string> {RemoteSettings.AndroidPushId},
                    Payload = new PushPayload
                        {
                            Alert = "Alert 2"
                        }
                };
            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(pushNotification, () => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
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
            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(pushNotification, () => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}