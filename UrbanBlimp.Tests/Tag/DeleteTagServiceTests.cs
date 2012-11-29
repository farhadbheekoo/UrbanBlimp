using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
#if (RELEASE)
[Ignore]
#endif
    public class DeleteTagServiceTests
    {

        [Test]
        public void Tags()
        {
            var service = new DeleteTagService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var helper = new AsyncTestHelper();
            var request = new DeleteTagRequest {Tag = "myTag"};
            service.Execute(request, response => helper.Callback(null), helper.HandleException);
            helper.Wait();
        }
    }
}