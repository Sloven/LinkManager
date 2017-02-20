using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entities;
using Microsoft.AspNet.Identity;
using NSubstitute;
using NUnit.Framework;
using WebAPI.Controllers;
using Services.Resources;

namespace Backend.UnitTest.WebApi.Links
{
    [TestFixture]
    public class LinkController
    {
        [TestCase("","")]
        public void AddNewUrl_EmptyUrl_ReturnsError(string userId, string URL)
        {
            var ils = Substitute.For<IResourcesService>();
            ils.AddLink(userId, URL).Returns(new Resource{Title = "someTitle",URL = URL,UserId = userId,CreatedAt = DateTime.Now});

            var lc = Substitute.For<ResourcesController>(ils);
            lc.CurrentUserId.Returns(userId);
            lc.PrepareResponse(HttpStatusCode.OK, "").Returns(new HttpResponseMessage(HttpStatusCode.OK));

            var okResp = new HttpResponseMessage(HttpStatusCode.OK);

            var result = lc.Post(URL);
            Assert.AreNotEqual(result, okResp);
        }

        [TestCase("")]
        public void GetRequest_ReturnsRecords(string userName)
        {
            var ils = Substitute.For<IResourcesService>();
            ils.GetAll(userName).Returns(new List<Resource> { new Resource(), new Resource(), new Resource()});

            var lc = Substitute.For<ResourcesController>(ils);
            lc.CurrentUserName.Returns(userName);

            var result = lc.Get();
            Assert.NotNull(result);
        }

    }
}
