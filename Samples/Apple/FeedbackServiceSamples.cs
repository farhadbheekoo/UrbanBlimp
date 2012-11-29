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
            var request = new FeedbackRequest
                              {
                                  Since = 10.Days().Ago()
                              };
            feedbackService.Execute(request, Callback, ExceptionHandler.Handle);
        }

        void Callback(FeedbackResponse response)
        {
            foreach (var deviceFeedback in response.DeviceFeedbacks)
            {
                Debug.WriteLine(deviceFeedback.Alias);
                Debug.WriteLine(deviceFeedback.DeviceToken);
                Debug.WriteLine(deviceFeedback.IsActive);
                Debug.WriteLine(deviceFeedback.MakedInactiveOn);
            }
        }
    }
}