using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Testing;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Owin;
using WebAPI;

namespace Backend.IntegrationTests
{
    [TestFixture]
    public class InMemoryHostingConfig
    {
        private readonly InMemoryServer server;
        protected InMemoryClient Client { get; private set; }
        readonly string tokenUrl = "oauth/token";

        public InMemoryHostingConfig()
        {
            var baseUrl = "http://localhost/";
            server = new InMemoryServer(baseUrl, tokenUrl);
        }

        public InMemoryHostingConfig(string baseUrl)
        {
            server = new InMemoryServer(baseUrl, tokenUrl);
        }


        [OneTimeSetUp]
        protected void RunBeforeAnyTests()
        {
            server.Startup();
            Client = server.GetClient();
        }

        [OneTimeTearDown]
        protected void RunAfterAnyTests()
        {
            server?.Shutdown();
        }

    }
}


