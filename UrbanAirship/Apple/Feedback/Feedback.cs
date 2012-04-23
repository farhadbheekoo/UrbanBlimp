using System;

namespace UrbanBlimp.Apple
{
    public class DeviceFeedback
    {
        public string DeviceToken;
        public DateTime? MakedInactiveOn;

        public bool IsActive
        {
            get { return MakedInactiveOn == null; }
        }

        public string Alias;
    }
}