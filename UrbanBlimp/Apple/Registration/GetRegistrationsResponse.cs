using System.Collections.Generic;

namespace UrbanBlimp.Apple
{
    public class GetRegistrationsResponse
    {
        public List<RegistrationSummary> Devices;
        public int DeviceTokensCount;
        public int ActiveDeviceTokensCount;
        public string NextPage;
        
    }

}