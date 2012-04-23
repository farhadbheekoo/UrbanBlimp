using System.Collections.Generic;
using System.Text;

namespace UrbanBlimp.Apple
{
    public class BatchPushService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public void Execute(IEnumerable<PushNotification> notifications)
        {
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/batch/");
            request.Method = "POST";
            request.ContentType = "application/json";
            var postData = PushNotificationSerializer.Serialize(notifications);
            var byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }
            using (request.GetResponse())
            {

            }
        }
    }
}