namespace UrbanBlimp.Android
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder;

        public void Execute(PushNotification notification)
        {
            var postData = PushNotificationSerializer.Serialize(notification);
            var request = RequestBuilder.Build("https://go.urbanairship.com/api/push/");
            request.Method = "POST";
            request.DoRequest(postData);
        }
    }
}