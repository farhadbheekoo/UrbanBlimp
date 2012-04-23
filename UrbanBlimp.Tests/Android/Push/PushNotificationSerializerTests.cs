using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Android;

namespace UrbanBlimp.Tests.Android
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
                                                         Extra = new Dictionary<string, string>
                                                                     {
                                                                         {"a","b"}
                                                                     },
                                                     },
                                       Aliases = new List<string> {"alias1"},
                                       Tags = new List<string> {"tag1"},
                                   };
            var text = PushNotificationSerializer.Serialize(notification).FormatAsJsom();
            var expected = @"
{
  'android': {
    'alert': 'My Alert',
    'extra': {
      'a': 'b'
    }
  },
  'aliases': [
    'alias1'
  ],
  'tags': [
    'tag1'
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
                                                                  Alert = "My Alert"
                                                              },
                                                Aliases = new List<string> {"alias1"}
                                            },
                                        new PushNotification
                                            {
                                                Payload = new PushPayload
                                                              {
                                                                  Alert = "My Alert",
                                                              },
                                                Aliases = new List<string> {"alias1"}
                                            }
                                    };
            var text = PushNotificationSerializer.Serialize(notifications).FormatAsJsom();

            var expected = @"
[
  {
    'android': {
      'alert': 'My Alert'
    },
    'aliases': [
      'alias1'
    ]
  },
  {
    'android': {
      'alert': 'My Alert'
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