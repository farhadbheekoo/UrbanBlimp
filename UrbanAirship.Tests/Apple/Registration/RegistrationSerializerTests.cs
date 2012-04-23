using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class RegistrationSerializerTests
    {
        [Test]
        public void Single2()
        {
            var registration = new Registration
            {
                Alias = "alias",
                Badge = 2,
                QuietTime = new QuietTime
                {
                    Start = "22:00",
                    End = "8:00"
                },
                Tags = new List<string> { "tag1", "tag2" },
                TimeZone = "America/Los_Angeles"
            };
            var text = RegistrationSerializer.Serialize(registration).FormatAsJsom();
            var expected = @"
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
}";
            Assert.AreEqual(expected, text);
        }
    }
}