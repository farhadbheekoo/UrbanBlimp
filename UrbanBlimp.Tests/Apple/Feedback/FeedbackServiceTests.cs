using System.Diagnostics;
using FluentDateTime;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class FeedbackServiceTests
    {
        [Test]
        [Ignore]
        public void Foo()
        {
            var feedbackService = new FeedbackService
                                      {
                                          RequestBuilder = RequestBuilderHelper.Build()
                                      };
            var feedback = feedbackService.Execute(10.Days().Ago());
            Debug.WriteLine(feedback.Count);
        }
    }
}