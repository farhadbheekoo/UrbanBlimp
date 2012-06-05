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

            var helper = new AsyncTestHelper<bool>();
            service.Execute("tag1434", helper.Callback, helper.HandleException);
            helper.Wait();
        }
    }
}