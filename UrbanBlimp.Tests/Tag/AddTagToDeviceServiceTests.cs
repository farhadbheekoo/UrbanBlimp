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

            var helper = new AsyncTestHelper();
            service.Execute(RemoteSettings.AppleDeviceId, "africa", helper.Callback, helper.HandleException);
            helper.Wait();
        }

    }
}