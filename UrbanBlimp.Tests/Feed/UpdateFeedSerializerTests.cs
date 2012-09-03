using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Feed;

namespace UrbanBlimp.Tests.Feed
{
    [TestFixture]
    public class UpdateFeedSerializerTests
    {
        [Test]
        public void Simple()
        {
            var newFeed = new UpdateFeed
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
                Url = "myUrl"
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
  'url': 'myUrl',
  'broadcast': true
}";
            Assert.AreEqual(expected, text);
        }
    }
}