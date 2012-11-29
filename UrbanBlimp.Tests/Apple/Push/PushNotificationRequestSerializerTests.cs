using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class PushNotificationRequestSerializerTests
    {
        [Test]
        public void Single()
        {
            var notification = new PushNotificationRequest
                                   {
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "My Alert",
                                                         Sound = "My Sound",
                                                         Badge = Badge.Increment()
                                                     },
                                       Aliases = new List<string> {"alias1"},
                                       Tags = new List<string> {"tag1"},
                                       DeviceTokens = new List<string> {"token1"},
                                       ExcludeTokens = new List<string> {"exclude1"},
                                   };
            var text = notification.Serialize().FormatAsJsom();
            var expected = @"
{
  'aps': {
    'alert': 'My Alert',
    'badge': '+1',
    'sound': 'My Sound'
  },
  'device_tokens': [
    'token1'
  ],
  'aliases': [
    'alias1'
  ],
  'tags': [
    'tag1'
  ],
  'exclude_tokens': [
    'exclude1'
  ]
}".Replace("\r\n", "\n");
            Assert.AreEqual(expected, text);
        }

    }
}