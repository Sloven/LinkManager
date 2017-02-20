using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Backend.IntegrationTests.User
{
    [TestFixture]
    public class Login: InMemoryHostingConfig
    {
        [TestCase("Test", "Test$123")]
        public void Login_with_correct_credentials_returns_token(string username, string password)
        {
            var token = base.Client.Login(username, password);

            Assert.NotNull(token);

            Assert.IsFalse(string.IsNullOrEmpty(token));
        }
    }
}
