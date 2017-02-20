using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Testing;
using Owin;
using WebAPI;

namespace Backend.IntegrationTests
{
    public class InMemoryServer: IDisposable
    {
        public readonly string BaseUrl;
        public readonly string TokenUrl;
        private TestServer _server;
        private InMemoryClient _client;

        public InMemoryServer(string baseUrl, string tokenUrl)
        {
            BaseUrl = baseUrl;
            TokenUrl = tokenUrl;
        }

        public void Startup()
        {
            _server = TestServer.Create(app =>
            {
                var config = new HttpConfiguration();
                var startup = new Startup();
                config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

                startup.Configuration(app, config);

                app.UseWebApi(config);
            });

            _client = new InMemoryClient(_server.Handler, BaseUrl, TokenUrl);
        }

        public void Shutdown()
        {
            _server?.Dispose();
        }

        public InMemoryClient GetClient()
        {
            if(_client == null)
                throw new InvalidOperationException("Server is not started");

            return _client;
        }

        public void Dispose()
        {
            _server?.Dispose();
        }

    }
}
