using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Apple;

namespace UrbanBlimp.Tests.Apple
{
    [TestFixture]

#if (RELEASE)
[Ignore]
#endif
    public class GetRegistrationsServiceTests
    {
        [Test]
        public void Integration()
        {
            var service = new GetRegistrationsService
                                      {
                                          RequestBuilder = RequestBuilderHelper.Build()
                                      };

            var helper = new AsyncTestHelper<GetRegistrationsResponse>();
            var request = new GetRegistrationsRequest();
            service.Execute(request, helper.Callback, helper.HandleException);
            helper.Wait();
            var response = helper.Response;
            foreach (var device in response.Devices)
            {
				Debug.WriteLine(device.DeviceToken);
            }
        }
    }
}