using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class GetTagServiceTests
    {

        [Test]
        public void Tags()
        {
            var service = new GetTagsService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            var helper = new AsyncTestHelper<GetTagsResponse>();
            service.Execute(helper.Callback, helper.HandleException);
            helper.Wait();

            foreach (var tag in helper.Response.Tags)
            {
                Debug.WriteLine(tag);
            }
        }
    }
}
