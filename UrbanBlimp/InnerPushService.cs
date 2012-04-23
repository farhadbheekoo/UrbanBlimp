using System.Text;

namespace UrbanBlimp
{
    static class InnerPushService
    {
        public static void Push(string postData, IRequestBuilder requestBuilder)
        {
            var request = requestBuilder.Build("https://go.urbanairship.com/api/push/");
            request.Method = "POST";
            var byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
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