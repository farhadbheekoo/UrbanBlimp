using System.Diagnostics;
using NUnit.Framework;
using UrbanBlimp.Tag;

namespace UrbanBlimp.Tests.Tag
{
    [TestFixture]
    public class GetTagServiceTests
    {

        [Test]
        [Ignore]
        public void Tags()
        {
            var service = new GetTagService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };
            ;
            var enumerable = service.Execute();
            foreach (var tag in enumerable)
            {
                Debug.WriteLine(tag);
            }
        }


    }
}
