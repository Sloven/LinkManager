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
    public class InMemoryClient: HttpClient
    {
        public readonly string TokenUrl;
        
        public InMemoryClient(HttpMessageHandler httpMessageHandler,string baseUrl, string tokenUrl):base(httpMessageHandler)
        {
            base.BaseAddress = new Uri(baseUrl);
            TokenUrl = tokenUrl;
        }

    }
}
