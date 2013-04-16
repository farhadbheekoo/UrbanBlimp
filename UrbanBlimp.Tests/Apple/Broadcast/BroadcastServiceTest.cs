using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
  public class BroadcastServiceTest
    {
        [Test]
        public void Simple()
        {
            var service = new BroadcastService
                {
                    RequestBuilder = RequestBuilderHelper.Build()
                };

            var broadcastNotification = new BroadcastNotificationRequest
                {
                    Payload = new PushPayload
                        {
                            Alert = "Alert 2",
                            Badge = Badge.Increment()
                        }
                };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(broadcastNotification, response => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}