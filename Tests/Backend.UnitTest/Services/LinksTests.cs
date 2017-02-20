using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.UnitTest.Fakes;
using DataAccess;
using Entities;
using WebAPI.Controllers;
using NUnit.Framework;
using Services.Resources;

namespace Backend.UnitTest.WebApi
{
    [TestFixture]
    public class LinksTests
    {
        private ResourceService ls;

        [SetUp]
        public void KickOff()
        {
            //arrange
            var CRUD = new FakeBasicCRUD<Resource>();
            ls = new ResourceService(CRUD);

            //add some link with user
            var user = new ApplicationUser() { UserName = "VeryImportantUser" };
            CRUD.Add(new Resource() { ResourceId = Guid.NewGuid(), ApplicationUser = user, Title = "testTitle", URL = "http://testurl.com" });

            user = new ApplicationUser() { UserName = "NotSoImportantUser" };
            CRUD.Add(new Resource() { ResourceId = Guid.NewGuid(), ApplicationUser = user, Title = "small fake link", URL = "http://fakelink.fakeit" });

            user = new ApplicationUser() { UserName = "Name_With_Spaces_Not_Allowed" };
            CRUD.Add(new Resource() { ResourceId = Guid.NewGuid(), ApplicationUser = user, Title = "huge url from google", URL = "https://www.google.com.ua/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=This+is+the+attribute+that+marks+a+class+that+contains+the+one-time+setup+or+teardown+methods+for+all+the+test+fixtures+under+a+given+namespace.+The+class+ma" });
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("UserNameNotExists")]
        [TestCase("User name with spaces not exists")]
        public void GetAll_WrongUserName_NoResults(string userName)
        {
            var links = ls.GetAll(userName);

            Assert.IsEmpty(links);
        }


        [TestCase("Name_With_Spaces_Not_Allowed")]
        public void GetAll_CorrectUserName_NotEmptyList(string userName)
        {
            var links = ls.GetAll(userName);

            Assert.IsNotEmpty(links);
        }


    }
}
