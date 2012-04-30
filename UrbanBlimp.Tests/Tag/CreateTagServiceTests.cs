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
            ;
            service.Execute("africa");
        }
    }
}