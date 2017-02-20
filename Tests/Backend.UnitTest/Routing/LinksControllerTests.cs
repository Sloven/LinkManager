using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyTested.WebApi;
using NUnit.Framework;
using WebAPI;
using WebAPI.Controllers;

namespace Backend.UnitTest.Routing
{
    [TestFixture]
    public class LinksControllerTests
    {
        [Test]
        public void Get_IsReachable()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Resources/")
                .WithHttpMethod(HttpMethod.Get)
                .To<ResourcesController>(c => c.Get());
        }

        [TestCase("anyusername")]
        public void PublicLinks_IsReachable(string userName)
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Resources/Public/")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent($"\"{userName}\"") //quotes are important
                .To<ResourcesController>(c => c.Public(userName));

        }
    }
}
