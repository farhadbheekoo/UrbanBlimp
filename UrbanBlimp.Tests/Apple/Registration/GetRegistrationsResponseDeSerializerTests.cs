using System.Linq;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class GetRegistrationsResponseDeSerializerTests
    {
        [Test]
        public void Simple()
        {
            using (var stream = @"
{
    'next_page': 'https://go.urbanairship.com/api/device_tokens/?start=1234123412341234123412341234123412341234123412341234123412341234&limit=5',
    'device_tokens_count': 875,
    'device_tokens': [
        {
            'device_token': '1234123412341234123412341234123412341234123412341234123412341234',
            'active': true,
            'alias': 'alias1',
            'tags': [
                  'tag1'
            ]
        }
    ],
    'active_device_tokens_count': 872
}".GetStream())
            {
                var response = GetRegistrationsResponseDeSerializer.DeSerialize(stream);
                Assert.AreEqual("https://go.urbanairship.com/api/device_tokens/?start=1234123412341234123412341234123412341234123412341234123412341234&limit=5", response.NextPage);
                Assert.AreEqual(872, response.ActiveDeviceTokensCount);
                Assert.AreEqual(875, response.DeviceTokensCount);
                var device = response.Devices.First();
                Assert.AreEqual("1234123412341234123412341234123412341234123412341234123412341234", device.DeviceToken);
                Assert.AreEqual("alias1", device.Alias);
                Assert.IsTrue(device.IsActive);
                Assert.AreEqual("tag1", device.Tags.First());
            }
        }


    }
}