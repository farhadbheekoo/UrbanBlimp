using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class RegistrationDeSerializerTests
    {

        [Test]
        public void Simple()
        {
            Registration registration;
            using (var stream = @"
{
    'quiettime': {
        'start': '22:00',
        'end': '8:00'
    },
    'alias': 'alias',
    'badge': 2,
    'tz': 'America/Los_Angeles',
    'tags': [
        'tag1',
        'tag2'
    ]
}".GetStream())
            {
                registration = RegistrationDeSerializer.DeSerialize(stream);
            }

            Assert.AreEqual("alias", registration.Alias);
            Assert.AreEqual(2, registration.Badge);
            Assert.AreEqual("America/Los_Angeles", registration.TimeZone);
            Assert.AreEqual("tag1", registration.Tags[0]);
            Assert.AreEqual("tag2", registration.Tags[1]);
            Assert.AreEqual("22:00", registration.QuietTime.Start);
            Assert.AreEqual("8:00", registration.QuietTime.End);
        }

    }
}