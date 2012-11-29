using System.Collections.Generic;
using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class ModifyTagServiceTests
    {

        [Test]
        public void Simple()
        {

            var service = new ModifyTagService
            {
                RequestBuilder = RequestBuilderHelper.Build()
            };
            var tokens = new ModifyTagRequest
            {
                Tag = "myTag",
                AddDeviceTokens = new List<string> { RemoteSettings.AppleDeviceId },
            };
            
            var asyncTestHelper = new AsyncTestHelper();
            service.Execute(tokens, response => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);

            asyncTestHelper.Wait();
        }

    }

}