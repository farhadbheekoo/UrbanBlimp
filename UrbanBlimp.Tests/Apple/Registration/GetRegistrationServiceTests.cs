using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
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
            var registration = service.Execute(RemoteSettings.AppleDeviceId);
            Debug.WriteLine(registration.Alias);
            Debug.WriteLine(registration.Badge);
            Debug.WriteLine(registration.QuietTime.Start);
            Debug.WriteLine(registration.QuietTime.End);
            Debug.WriteLine(string.Join(" ", registration.Tags));
            Debug.WriteLine(registration.TimeZone);
        }


        [Test]
        [Ignore]
        public void NotFound()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            var registration = service.Execute("foo");
            Assert.IsNull(registration);
        }

    }
}