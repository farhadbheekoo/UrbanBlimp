using System;
using NUnit.Framework;
using UrbanBlimp.Feed;

namespace UrbanBlimp.Tests.Feed
{
    [TestFixture]
    public class FeedDeSerializerTests
    {

        [Test]
        public void Simple()
        {
            var value = @"
[
    {
        'url': 'url1',
        'template': {
            'aps': {
                'badge': 1,
                'alert': 'alert1',
                'sound': 'sound1'
            },
            'tags': ['tag1']
        },
        'id': '1',
        'last_checked': '2009-06-22 10:05:00',
        'feed_url': 'feedUrl1',
        'broadcast': true
    }
]";
            var feeds = value.ToObject(FeedDeSerializer.DeSerialize);
            var feed0 = feeds[0];
            Assert.AreEqual("1", feed0.Id);
            var feedPayload = feed0.Template.FeedPayload;
            Assert.AreEqual("alert1", feedPayload.Alert);
            Assert.AreEqual(1, feedPayload.Badge);
            Assert.AreEqual("sound1", feedPayload.Sound);
            Assert.Contains("tag1",feed0.Template.Tags);
            Assert.AreEqual("feedUrl1", feed0.FeedUrl);
            Assert.AreEqual("url1", feed0.Url);
            Assert.IsTrue(feed0.BroadCast);
            Assert.AreEqual(new DateTime(2009, 06, 22, 10, 05, 00), feed0.LastChecked);
        }

    }
}