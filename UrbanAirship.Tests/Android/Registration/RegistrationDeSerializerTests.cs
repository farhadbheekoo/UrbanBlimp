using System;
using NUnit.Framework;
using UrbanBlimp.Android;

namespace UrbanBlimp.Tests.Android
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
  'alias' : 'alias',
  'created' : '2009-11-06 20:41:06',
  'active' : true,
  'tags' : 
    [
      'tag1',
      'tag2'
    ],
}".GetStream())
            {
                registration = RegistrationDeSerializer.DeSerialize(stream);
            }

            Assert.AreEqual("alias", registration.Alias);
            Assert.AreEqual(new DateTime(2009,11,06,20,41,6), registration.Created);
            Assert.IsTrue(registration.Active);
            Assert.AreEqual("tag1", registration.Tags[0]);
            Assert.AreEqual("tag2", registration.Tags[1]);
        }

    }
}