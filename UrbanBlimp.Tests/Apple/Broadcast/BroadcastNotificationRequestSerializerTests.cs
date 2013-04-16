using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;


namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class BroadcastNotificationRequestSerializerTests
    {
        [Test]
        public void Single()
        {
            var notification = new BroadcastNotificationRequest
                                   {
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "My Alert",
                                                         Sound = "My Sound",
                                                         Badge = Badge.Increment()
                                                     },
                                       ExcludeTokens = new List<string> {"exclude1"},
                                   };
            var actual = notification.Serialize().FormatAsJson();
            var expected = @"
{
  'aps': {
    'alert': 'My Alert',
    'badge': '+1',
    'sound': 'My Sound'
  },
  'exclude_tokens': [
    'exclude1'
  ]
}".Replace("\r\n", "\n");
            Assert.AreEqual(expected, actual);
        }
    }
}