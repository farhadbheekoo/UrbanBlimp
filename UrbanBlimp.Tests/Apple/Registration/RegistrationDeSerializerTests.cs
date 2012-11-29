using System;
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
            var value = @"
{
    'last_registration': '2009-06-22 10:05:00',
    'quiettime': {
        'start': '22:00',
        'end': '8:00'
    },
    'alias': 'alias',
    'active': 'true',
    'badge': 2,
    'tz': 'America/Los_Angeles',
    'tags': [
        'tag1',
        'tag2'
    ]
}";
            var registration = value.ToObject(GetRegistrationResponseDeSerializer.DeSerialize);
            Assert.AreEqual(new DateTime(2009, 06, 22, 10, 05, 00), registration.LastRegistration);
            Assert.IsTrue(registration.Active);
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