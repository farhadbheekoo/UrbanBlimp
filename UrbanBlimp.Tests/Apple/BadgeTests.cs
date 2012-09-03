using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class BadgeTests
    {

        [Test]
        public void TagToDevice()
        {
            Assert.AreEqual("auto", Badge.Auto());
            Assert.AreEqual("+1", Badge.Increment());
            Assert.AreEqual("-1", Badge.Decrement());
            Assert.AreEqual("auto", Badge.Increment(0));
            Assert.AreEqual("auto", Badge.Decrement(0));
            Assert.AreEqual("+1", Badge.Increment(1));
            Assert.AreEqual("-1", Badge.Decrement(1));
            Assert.AreEqual("+2", Badge.Increment(2));
            Assert.AreEqual("-2", Badge.Decrement(2));
            Assert.AreEqual("-2", Badge.Increment(-2));
            Assert.AreEqual("+2", Badge.Decrement(-2));
        }

    }
}