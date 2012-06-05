using System.Collections.Generic;
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
            var helper = new AsyncTestHelper<List<string>>();
            service.Execute(helper.Callback, helper.HandleException);
            helper.Wait();

            foreach (var tag in helper.Response)
            {
                Debug.WriteLine(tag);
            }
        }

        [Test]
        [Ignore]
        public void TagsForDevices()
        {
            var service = new GetTagService
                              {
                                  RequestBuilder = RequestBuilderHelper.Build()
                              };


            var helper = new AsyncTestHelper<List<string>>();
            service.Execute("tag1434", helper.Callback, helper.HandleException);
            helper.Wait();

            foreach (var tag in helper.Response)
            {
                Debug.WriteLine(tag);
            }
        }


    }
}
