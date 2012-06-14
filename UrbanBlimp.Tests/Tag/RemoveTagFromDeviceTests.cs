using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class RemoveTagFromDeviceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new RemoveTagFromDeviceService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var helper = new AsyncTestHelper();
            service.Execute("DeviceId", "tag1434", () => helper.Callback(null), helper.HandleException);
            helper.Wait();
        }
    }
}