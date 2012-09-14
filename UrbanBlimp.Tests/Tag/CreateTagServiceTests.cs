using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class CreateTagServiceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new CreateTagService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var asyncTestHelper = new AsyncTestHelper();
            service.Execute("africa", () => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}