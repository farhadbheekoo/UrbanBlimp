using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class DeleteTagServiceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new DeleteTagService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var helper = new AsyncTestHelper();
            service.Execute("tag1434", () => { helper.Callback(null); }, helper.HandleException);
            helper.Wait();
        }
    }
}