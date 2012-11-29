using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class CreateTagServiceTests
    {

        [Test]
        public void Tags()
        {
            var service = new CreateTagService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };

            var asyncTestHelper = new AsyncTestHelper();
            var request = new CreateTagRequest {Tag = "myTag"};
            service.Execute(request, response => asyncTestHelper.Callback(null), asyncTestHelper.HandleException);
            asyncTestHelper.Wait();
        }
    }
}