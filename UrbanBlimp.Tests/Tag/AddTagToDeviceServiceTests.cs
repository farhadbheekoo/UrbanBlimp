using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class AddTagToDeviceServiceTests
    {

        [Test]
        public void TagToDevice()
        {
            var service = new AddTagToDeviceService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var asyncTestHelper = new AsyncTestHelper();
            var request = new AddTagToDeviceRequest
                              {
                                  DeviceToken = RemoteSettings.AppleDeviceId,
                                  Tag = "africa"
                              };
            service.Execute(request, response => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }

    }

}