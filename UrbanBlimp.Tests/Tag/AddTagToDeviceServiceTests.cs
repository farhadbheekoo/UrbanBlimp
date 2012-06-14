using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class AddTagToDeviceServiceTests
    {

        [Test]
        [Ignore]
        public void TagToDevice()
        {
            var service = new AddTagToDeviceService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(RemoteSettings.AppleDeviceId, "africa", () => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }

    }
}