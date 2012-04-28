using System.Linq;
using NUnit.Framework;
using UrbanBlimp.Tags;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class TagDeSerializerTests
    {
        [Test]
        public void Single2()
        {
            var expected = @"
{
  'tags': [
    'tag1',
    'tag2'
  ]
}";
            var tags = expected.ToObject(TagDeSerializer.DeSerialize).ToList();
            Assert.Contains("tag1", tags);
            Assert.Contains("tag2", tags);
        }
    }
}