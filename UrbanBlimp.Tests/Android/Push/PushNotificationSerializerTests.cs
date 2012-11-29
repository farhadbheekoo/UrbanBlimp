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
            var notification = new PushNotificationRequest
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
            var text = notification.Serialize().FormatAsJsom();
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
}".Replace("\r\n", "\n");
            Assert.AreEqual(expected, text);
        }

    }
}