using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class GetTagForDeviceServiceTests
    {

        [Test]
        public void TagsForDevices()
        {
            var service = new GetTagsForDeviceService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };


            var helper = new AsyncTestHelper<GetTagsForDeviceResponse>();
            var request = new GetTagsForDeviceRequest {DeviceToken = RemoteSettings.AppleDeviceId};
            service.Execute(request, helper.Callback, helper.HandleException);
            helper.Wait();

            foreach (var tag in helper.Response.Tags)
            {
                Debug.WriteLine(tag);
            }
        }


    }
}