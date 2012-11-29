using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class RemoveTagFromDeviceTests
    {

        [Test]
        public void Tags()
        {
            var service = new RemoveTagFromDeviceService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var helper = new AsyncTestHelper();
            var request = new RemoveTagFromDeviceRequest
                              {
                                  DeviceToken = "DeviceId",
                                  TagToRemove = "tag1434"
                              };
            service.Execute(request, response => helper.Callback(null), helper.HandleException);
            helper.Wait();
        }
    }
}