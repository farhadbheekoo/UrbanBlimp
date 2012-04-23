namespace UrbanBlimp.Android
{
    public class PushService
    {
        public IRequestBuilder RequestBuilder { get; set; }

        public void Execute(PushNotification notification)
        {
            var postData = PushNotificationSerializer.Serialize(notification);
            InnerPushService.Push(postData, RequestBuilder);
        }
    }
}
