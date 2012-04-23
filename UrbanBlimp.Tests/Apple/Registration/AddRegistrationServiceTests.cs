using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
    public class AddRegistrationServiceTests
    {


        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new AddRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            var registration = new Registration
                                   {
                                       Tags = new List<string> {"bangladesh"}
                                   };
            service.Execute(RemoteSettings.AppleDeviceId, registration);
        }

    }
}