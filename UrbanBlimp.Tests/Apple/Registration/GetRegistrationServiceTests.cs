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


            var helper = new AsyncTestHelper<Registration>();
            service.Execute(RemoteSettings.AppleDeviceId, helper.Callback, helper.HandleException);
            helper.Wait();

            var registration = helper.Response;
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


            var helper = new AsyncTestHelper<Registration>();
            service.Execute("foo", helper.Callback, helper.HandleException);
            helper.Wait();
            Assert.IsNull(helper.Response);
        }

    }
}