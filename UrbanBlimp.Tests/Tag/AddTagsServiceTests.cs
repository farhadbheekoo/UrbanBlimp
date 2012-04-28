using NUnit.Framework;
using UrbanBlimp.Tags;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class AddTagsServiceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new AddTagsService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };;
            service.Execute("africa");
        }

        [Test]
        [Ignore]
        public void TagToDevice()
        {
            var service = new AddTagsService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            service.Execute("africa", RemoteSettings.AppleDeviceId);
        }

    }
}