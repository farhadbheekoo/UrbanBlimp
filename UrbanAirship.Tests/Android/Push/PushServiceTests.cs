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
            service.Execute(new PushNotification
                                {
                                    PushIds = new List<string> {RemoteSettings.AndroidPushId},
                                    Payload = new PushPayload
                                                  {
                                                      Alert = "Alert 2"
                                                  }

                                });
        }

        [Test]
        [Ignore]
        public void ToTag()
        {
            var service = new PushService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            service.Execute(new PushNotification
                                {
                                    Tags = new List<string> {"africa"},
                                    Payload = new PushPayload
                                                  {
                                                      Alert = "Alert 2"
                                                  }

                                });
        }
    }
}