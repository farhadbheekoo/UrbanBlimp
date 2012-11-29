using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class AddRegistrationServiceTests
    {


        [Test]
        public void Tags()
        {
            var service = new AddRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            var registration = new AddRegistrationRequest
                                   {
                                       DeviceToken = RemoteSettings.AppleDeviceId,
                                       Tags = new List<string>
                                           {
                                               "bangladesh",
                                           }
                                   };


            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(registration, x => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }

    }
}