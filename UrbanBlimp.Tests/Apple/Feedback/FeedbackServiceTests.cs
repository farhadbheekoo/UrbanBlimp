using System.Diagnostics;
using System.Linq;
using FluentDateTime;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class FeedbackServiceTests
    {
        [Test]
        public void Foo()
        {
            var feedbackService = new FeedbackService
                                      {
                                          RequestBuilder = RequestBuilderHelper.Build()
                                      };
            var feedback = feedbackService.Execute(10.Days().Ago()).ToList();
            Debug.WriteLine(feedback.Count);
        }
    }
}