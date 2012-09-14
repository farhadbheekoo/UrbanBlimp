using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Feed;

namespace UrbanBlimp.Tests.Feed
{
    [TestFixture]
    public class NewFeedSerializerTests
    {
        [Test]
        public void Simple()
        {
            var newFeed = new NewFeed
            {
                FeedUrl = "http://example.com/atom.",
                BroadCast = true,
                Template = new Template
                               {
                                   FeedPayload = new FeedPayload
                                                     {
                                                         Alert = "MyAlert",
                                                         Badge = 10,
                                                         Sound = "MySound"
                                                     },
                                   Tags = new List<string> { "tag1", "tag2" }
                               },
            };
            var text = newFeed.Serialize().FormatAsJsom();
            var expected = @"
{
  'template': {
    'aps': {
      'alert': 'MyAlert',
      'badge': 10,
      'sound': 'MySound'
    },
    'tags': [
      'tag1',
      'tag2'
    ]
  },
  'feed_url': 'http://example.com/atom.',
  'broadcast': true
}";
            Assert.AreEqual(expected, text);
        }
    }
}