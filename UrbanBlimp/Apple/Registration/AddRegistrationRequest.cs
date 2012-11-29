using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class AddRegistrationRequest
    {
        public string DeviceToken;
        public string Alias;
        public int? Badge;
        public string TimeZone;
        public QuietTime QuietTime;
        public List<string> Tags;
    }
}