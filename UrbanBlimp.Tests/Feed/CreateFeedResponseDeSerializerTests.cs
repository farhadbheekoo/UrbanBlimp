using System;
using NUnit.Framework;
using UrbanBlimp.Feed;

namespace UrbanBlimp.Tests.Feed
{
    [TestFixture]
    public class CreateFeedResponseDeSerializerTests
    {

        [Test]
        public void Simple()
        {
            var value = @"
{
    'url': 'url1',
    'id': 'feedid',
    'last_checked': '2009-06-22 10:05:00'
}";
            var feeds = value.ToObject(CreateFeedResponseDeSerializer.DeSerialize);
            Assert.AreEqual("feedid", feeds.Id);
            Assert.AreEqual("url1", feeds.Url);
            Assert.AreEqual(new DateTime(2009, 06, 22, 10, 05, 00), feeds.LastChecked);
        }

    }
}