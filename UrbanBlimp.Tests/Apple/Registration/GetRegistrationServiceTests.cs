using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class GetRegistrationServiceTests
    {

        [Test]
        public void Simple()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };


            var helper = new AsyncTestHelper<GetRegistrationResponse>();
            var getRegistrationRequest = new GetRegistrationRequest
                                             {
                                                 DeviceToken = RemoteSettings.AppleDeviceId
                                             };
            service.Execute(getRegistrationRequest, helper.Callback, helper.HandleException);
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
        public void NotFound()
        {
            var service = new GetRegistrationService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };


            var helper = new AsyncTestHelper<GetRegistrationResponse>();
            var getRegistrationRequest = new GetRegistrationRequest
                                             {
                                                 DeviceToken = "foo"
                                             };
            service.Execute(getRegistrationRequest, helper.Callback, helper.HandleException);
            helper.Wait();
            Assert.IsNull(helper.Response);
        }

    }
}