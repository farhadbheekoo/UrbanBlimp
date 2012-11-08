using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class FeedbackSerializerTests
    {
        [Test]
        public void MarkedAsInactive()
        {
            List<DeviceFeedback> feedbacks;
            using (var stream = @"
[
    {
        'device_token': '1234123412341234123412341234123412341234123412341234123412341234',
        'marked_inactive_on': '2009-06-22 10:05:00',
        'alias': 'bob'
    }
]".GetStream())
            {
                feedbacks = FeedbackSerializer.DeSerialize(stream).ToList();
            }
            var feedback = feedbacks.First();
            Assert.AreEqual("1234123412341234123412341234123412341234123412341234123412341234", feedback.DeviceToken);
            Assert.AreEqual("bob", feedback.Alias);
            Assert.AreEqual(new DateTime(2009, 06, 22, 10, 05, 00), feedback.MakedInactiveOn);
        }

        [Test]
        public void Active()
        {
            List<DeviceFeedback> feedbacks;
            using (var stream = @"
[
    {
        'device_token': '6334C016FC643BAA340ECA25BC661D15055A07B475E9A6108F3F644B15DD05AC',
        'active': true,
        'alias': null,
    }
],".GetStream())
            {
                feedbacks = FeedbackSerializer.DeSerialize(stream).ToList();
            }
            var feedback = feedbacks.First();
            Assert.IsNull(feedback.MakedInactiveOn);
            Assert.IsTrue(feedback.IsActive);
        }

    
    
    }
}