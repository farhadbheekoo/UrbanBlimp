using System.Collections.Generic;
using System.Diagnostics;
using FluentDateTime;
using UrbanBlimp.Apple;

namespace Apple
{
    public class FeedbackServiceSamples
    {
        public void Simple()
        {
            var feedbackService = new FeedbackService
                                      {
                                          RequestBuilder = ServerRequestBuilder.Instance
                                      };
            feedbackService.Execute(10.Days().Ago(), Callback, ExceptionHandler.Handle);
        }

        void Callback(List<DeviceFeedback> feedback)
        {
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