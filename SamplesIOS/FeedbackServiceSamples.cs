using System.Diagnostics;
using FluentDateTime;
using UrbanBlimp.Apple;

namespace Samples
{
    public class FeedbackServiceSamples
    {
        public void Simple()
        {
            var feedbackService = new FeedbackService
                                      {
                                          RequestBuilder = CustomRequestBuilder.GetRequestBuilder()
                                      };
            var feedback = feedbackService.Execute(10.Days().Ago());
            foreach (var deviceFeedback in feedback)
            {
                Debug.WriteLine(deviceFeedback.Alias);
                Debug.WriteLine(deviceFeedback.DeviceToken);
                Debug.WriteLine(deviceFeedback.IsActive);
                Debug.WriteLine(deviceFeedback.MakedInactiveOn);
            }
        }
    }
}