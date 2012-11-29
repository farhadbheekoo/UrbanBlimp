using System;
using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class GetRegistrationResponse
    {
        public string Alias;
        public int? Badge;
        public string TimeZone;
        public QuietTime QuietTime;
        public List<string> Tags;
        public bool Active;
        public DateTime LastRegistration;
    }
}