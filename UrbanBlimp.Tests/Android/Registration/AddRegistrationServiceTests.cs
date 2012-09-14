using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Android;

namespace UrbanBlimp.Tests.Android
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
            var registration = new NewRegistration
                                   {
                                       Tags = new List<string> {"bangladesh"}
                                   };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(RemoteSettings.AndroidPushId, registration, () => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}