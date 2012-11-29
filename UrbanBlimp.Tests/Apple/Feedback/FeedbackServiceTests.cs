using System.Diagnostics;
using FluentDateTime;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]

#if (RELEASE)
[Ignore]
#endif
    public class FeedbackServiceTests
    {
        [Test]
        public void Integration()
        {
            var feedbackService = new FeedbackService
                                      {
                                          RequestBuilder = RequestBuilderHelper.Build()
                                      };

            var helper = new AsyncTestHelper<FeedbackResponse>();
            var request = new FeedbackRequest
                              {
                                  Since = 10.Days().Ago()
                              };
            feedbackService.Execute(request, helper.Callback, helper.HandleException);
            helper.Wait();
            var deviceFeedbacks = helper.Response.DeviceFeedbacks;
            Debug.WriteLine(deviceFeedbacks.Count);
            foreach (var deviceFeedback in deviceFeedbacks)
            {
				Debug.WriteLine(deviceFeedback.DeviceToken);
				Debug.WriteLine(deviceFeedback.MakedInactiveOn);   
            }
        }
    }
}