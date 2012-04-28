using NUnit.Framework;
using UrbanBlimp.Tags;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class RemoveTagsServiceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new RemoveTagsService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            
            service.Execute("tag1434");
        }
    }
}