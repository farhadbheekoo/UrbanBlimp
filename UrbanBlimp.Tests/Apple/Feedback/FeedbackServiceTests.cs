using System.Diagnostics;
using FluentDateTime;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    [Ignore]
    public class FeedbackServiceTests
    {
        [Test]
        [Ignore]
        public void Integration()
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