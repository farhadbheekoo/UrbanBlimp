using System.Collections.Generic;
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

            var helper = new AsyncTestHelper<List<DeviceFeedback>>();
            feedbackService.Execute(10.Days().Ago(),helper.Callback, helper.HandleException);
            helper.Wait();
            Debug.WriteLine(helper.Response.Count);   
            foreach (var deviceFeedback in helper.Response)
            {
                Debug.WriteLine(deviceFeedback.DeviceToken);   
            }
        }
    }
}