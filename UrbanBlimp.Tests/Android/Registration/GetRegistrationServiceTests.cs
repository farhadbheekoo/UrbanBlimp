using NUnit.Framework;
using UrbanBlimp.Android;

namespace UrbanBlimp.Tests.Android
{
    [TestFixture]
    public class GetRegistrationServiceTests
    {

        [Test]
        [Ignore]
        public void Simple()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            var helper = new AsyncTestHelper<Registration>();
            service.Execute(RemoteSettings.AndroidPushId, helper.Callback, helper.HandleException);
            helper.Wait();
        }
        [Test]
        [Ignore]
        public void NotFound()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var helper = new AsyncTestHelper<Registration>();
            service.Execute(RemoteSettings.AndroidPushId, helper.Callback, helper.HandleException);
            helper.Wait();
            Assert.IsNull(helper.Response);
        }
    }
}