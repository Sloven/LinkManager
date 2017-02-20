using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Backend.IntegrationTests.Links
{
    [TestFixture]
    public class ResourcesTests:InMemoryHostingConfig
    {
        [TestCase("api/resources/public","test")]
        public void PostToPublicLinks_Return_AvailablePublic(string uri, string userName)
        {
            var response= base.Client.PostRequest(uri, $"\"{userName}\"");
            var mess = response.Content.ReadAsStringAsync().Result;

            var collect = JsonConvert.DeserializeObject<dynamic>(mess);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK, mess);
            Assert.NotNull(collect);
        }

        [TestCase("api/resources")]
        public void Anonimous_Get_Is_Unauthorized(string uri)
        {
            var response = base.Client.SendRequest(uri, HttpMethod.Get);
            var mess = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized, mess);
        }

        [TestCase("api/resources", "Test", "Test$123")]
        public void RegisteredUser_Get_AllLinks_Successfull(string uri,string username, string password)
        {
            var access_token = this.Client.Login(username, password);
            var headers = new Dictionary<string,string> {["Authorization"] = "Bearer " + access_token};

            var response = this.Client.SendRequest(uri, HttpMethod.Get, headers);

            var mess = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, mess);
        }

        [TestCase("http://tessample#somesimplelink.dom", "Resource title")]
        public void AddNewLink_ToRegisteredUser_Success(string newLinkUri, string title)
        {
            
        }

    }
}
