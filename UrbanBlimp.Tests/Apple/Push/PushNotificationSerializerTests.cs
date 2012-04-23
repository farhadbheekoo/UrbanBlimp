using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class PushNotificationSerializerTests
    {
        [Test]
        public void Single()
        {
            var notification = new PushNotification
                                   {
                                       Payload = new PushPayload
                                                     {
                                                         Alert = "My Alert",
                                                         Sound = "My Sound",
                                                         Badge = "+1"
                                                     },
                                       Aliases = new List<string> {"alias1"},
                                       Tags = new List<string> {"tag1"},
                                       DeviceTokens = new List<string> {"token1"},
                                       ExcludeTokens = new List<string> {"exclude1"},
                                   };
            var text = PushNotificationSerializer.Serialize(notification).FormatAsJsom();
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
}";
            Assert.AreEqual(expected, text);
        }

        [Test]
        public void List()
        {
            var notifications = new[]
                                    {
                                        new PushNotification
                                            {
                                                Payload = new PushPayload
                                                              {
                                                                  Alert = "My Alert", Sound = "My Sound",
                                                                  Badge = "+1"
                                                              },
                                                Aliases = new List<string> {"alias1"}
                                            },
                                        new PushNotification
                                            {
                                                Payload = new PushPayload
                                                              {
                                                                  Alert = "My Alert",
                                                                  Sound = "My Sound",
                                                                  Badge = "+1"
                                                              },
                                                Aliases = new List<string> {"alias1"}
                                            }
                                    };
            var text = PushNotificationSerializer.Serialize(notifications).FormatAsJsom();

            var expected =@"
[
  {
    'aps': {
      'alert': 'My Alert',
      'badge': '+1',
      'sound': 'My Sound'
    },
    'aliases': [
      'alias1'
    ]
  },
  {
    'aps': {
      'alert': 'My Alert',
      'badge': '+1',
      'sound': 'My Sound'
    },
    'aliases': [
      'alias1'
    ]
  }
]";
            Assert.AreEqual(expected, text);
        }
    }
}