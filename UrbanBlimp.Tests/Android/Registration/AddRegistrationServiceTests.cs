using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Android;

namespace UrbanBlimp.Tests.Android
{
    [TestFixture]
    [Ignore]
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
                                       PushId = RemoteSettings.AndroidPushId,
                                       Tags = new List<string> {"bangladesh"}
                                   };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(registration, x => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}