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
            var registration = service.Execute(RemoteSettings.AndroidPushId);

        }
        [Test]
        [Ignore]
        public void NotFound()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            var registration = service.Execute("Foo");
            Assert.IsNull(registration);
        }
    }
}