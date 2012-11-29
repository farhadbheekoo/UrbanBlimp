using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class ModifyTagRequestSerializerTests
    {
        [Test]
        public void Simple()
        {
            var registration = new ModifyTagRequest
            {
                AddDevicePins = new List<string> { "AddDevicePin1", "AddDevicePin2" },
                RemoveDevicePins = new List<string> { "RemoveDevicePin1", "RemoveDevicePin2" },
                AddDeviceTokens = new List<string> { "AddDeviceToken1", "AddDeviceToken2" },
                RemoveDeviceTokens = new List<string> { "RemoveDeviceToken1", "RemoveDeviceToken2" },
                AddPushIds = new List<string> { "AddPushId1", "AddPushId2" },
                RemovePushIds = new List<string> { "RemovePushId1", "RemovePushId2" }
            };
            var text = registration.Serialize().FormatAsJsom();
            var expected = @"
{
  'device_tokens': {
    'add': [
      'AddDeviceToken1',
      'AddDeviceToken2'
    ],
    'remove': [
      'RemoveDeviceToken1',
      'RemoveDeviceToken2'
    ]
  },
  'device_pins': {
    'add': [
      'AddDevicePin1',
      'AddDevicePin2'
    ],
    'remove': [
      'RemoveDevicePin1',
      'RemoveDevicePin2'
    ]
  },
  'apids': {
    'add': [
      'AddPushId1',
      'AddPushId2'
    ],
    'remove': [
      'RemovePushId1',
      'RemovePushId2'
    ]
  }
}".Replace("\r\n", "\n");
            Assert.AreEqual(expected, text);
        }
    }
}