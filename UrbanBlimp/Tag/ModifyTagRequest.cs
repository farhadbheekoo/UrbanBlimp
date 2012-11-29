using System.Collections.Generic;

namespace UrbanBlimp.Tag
{
    public class ModifyTagRequest
    {
        public string Tag;
        public List<string> AddDeviceTokens;
        public List<string> RemoveDeviceTokens;
        public List<string> AddDevicePins;
        public List<string> RemoveDevicePins;
        public List<string> AddPushIds;
        public List<string> RemovePushIds;
    }
}