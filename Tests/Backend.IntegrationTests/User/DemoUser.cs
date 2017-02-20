using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Backend.IntegrationTests.User
{

    [TestFixture]
    public class DemoUser : InMemoryHostingConfig
    {
        private readonly string demoUserId;
        private readonly string email;
        private bool registered;
        private readonly Dictionary<string, string> isDemoHeader = new Dictionary<string, string> { ["isDemo"] = "true" };
        public DemoUser()
        {
            demoUserId = "testUserForDemo#" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "");
            email = $"{demoUserId}@test.com";
        }

        [Test]
        public void Demo_User_registration()
        {
            string uri = "api/account/register";

            var newUser = new {userName = demoUserId, email, password = demoUserId, confirmPassword = demoUserId};
            var data = JsonConvert.SerializeObject(newUser);

            var response = base.Client.PostRequest(uri, isDemoHeader, data);
            var mess = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, mess);
            registered = true;
        }

        [Test]
        public void Demo_User_Registration_then_login()
        {
            if(!registered)
                Demo_User_registration();

            var data = $"userName={Uri.EscapeDataString(demoUserId)}&password={Uri.EscapeDataString(demoUserId)}&grant_type=password";
            
            var response = base.Client.PostRequest(base.Client.TokenUrl, isDemoHeader, data);
            var tokenMess = response.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeAnonymousType(tokenMess, new { access_token = "" });
            
            Assert.NotNull(token?.access_token);
            Assert.IsFalse(string.IsNullOrEmpty(token?.access_token));
        }


    
    }
}
