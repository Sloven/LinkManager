using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Backend.IntegrationTests.User
{
    [TestFixture]
    [Category("Register")]
    public class Register:InMemoryHostingConfig
    {
        [TestCase("Test","Test$123")]
        public void Register_TestUser_ifNotExists_Success(string username,string password)
        {
            var token = this.Client.Login(username, password);
            if (token != null)
                return;

            string uri = "api/account/register";
            string email = $"{username}@test.com";
            var newUser = new { username, email, password, confirmPassword = password };
            var data = JsonConvert.SerializeObject(newUser);

            var response = base.Client.PostRequest(uri, data);

            var mess = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, mess);
            Assert.Pass(mess);
        }

        [TestCase("api/account/register")]
        public void PostEmptyModel_throw_ModelStateInvalid(string uri)
        {
            var response = base.Client.PostRequest(uri);

            var mess = response.Content.ReadAsStringAsync().Result;
            var exception = JsonConvert.DeserializeAnonymousType(mess, new { ExceptionMessage = "" });
            Assert.NotNull(exception?.ExceptionMessage);
        }

        [Test]
        public void Register_newRandomUser_Success()
        {
            string uri = "api/account/register";
            string username = "tessample#" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "");
            string password = "Test@123";
            string email = $"{username}@test.com";
            var newUser = new { username, email, password, confirmPassword = password };
            var data = JsonConvert.SerializeObject(newUser);

            var response = base.Client.PostRequest(uri, data);

            var mess = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, mess);
            Assert.Pass(mess);
        }
    }
}
