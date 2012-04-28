using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Tags;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class GetTagsServiceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new GetTagsService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            ;
            var enumerable = service.Execute();
            foreach (var tag in enumerable)
            {
                Debug.WriteLine(tag);
            }
        }

        [Test]
        [Ignore]
        public void TagToDevice()
        {
            var service = new AddTagsService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            ;
            service.Execute("africa", RemoteSettings.AppleDeviceId);
        }

    }
}
