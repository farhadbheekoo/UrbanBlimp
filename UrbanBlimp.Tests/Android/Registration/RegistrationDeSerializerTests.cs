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
            GetRegistrationResponse getRegistrationResponse;
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
                getRegistrationResponse = GetRegistrationResponseDeSerializer.DeSerialize(stream);
            }

            Assert.AreEqual("alias", getRegistrationResponse.Alias);
            Assert.AreEqual(new DateTime(2009,11,06,20,41,6), getRegistrationResponse.Created);
            Assert.IsTrue(getRegistrationResponse.Active);
            Assert.AreEqual("tag1", getRegistrationResponse.Tags[0]);
            Assert.AreEqual("tag2", getRegistrationResponse.Tags[1]);
        }

    }
}