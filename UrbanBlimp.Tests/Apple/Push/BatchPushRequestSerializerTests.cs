using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class BatchPushRequestSerializerTests
    {

        [Test]
        public void List()
        {
            var request = new BatchPushRequest
                              {
                                  Notifications = new List<PushNotification>
                                                      {
                                                          new PushNotification
                                                              {
                                                                  Payload = new PushPayload
                                                                                {
                                                                                    Alert = "My Alert", 
                                                                                    Sound = "My Sound", 
                                                                                    Badge = Badge.Increment()
                                                                                },
                                                                  Aliases = new List<string> {"alias1"}
                                                              },
                                                          new PushNotification
                                                              {
                                                                  Payload = new PushPayload
                                                                                {
                                                                                    Alert = "My Alert", 
                                                                                    Sound = "My Sound", 
                                                                                    Badge = Badge.Increment()
                                                                                },
                                                                  Aliases = new List<string> {"alias1"}
                                                              }
                                                      }
                              };
            var text = request.Serialize().FormatAsJson();

            var expected = @"
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
]".Replace("\r\n", "\n");
            Assert.AreEqual(expected, text);
        }
    }
}