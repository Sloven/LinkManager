using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using DataAccess;
using DataAccess.Abstractions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using StructureMap;
using WebAPI.CustomMiddleware;
using WebAPI.DependencyResolution;
using WebAPI.Handlers;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;
            PreConfig(app, config);
        }

        /// <summary>
        /// Use for In-memory hosting
        /// </summary>
        public void Configuration(IAppBuilder app, HttpConfiguration config)
        {
            PreConfig(app, config);
        }

        private void PreConfig(IAppBuilder app, HttpConfiguration config)
        {

            var conStrName = "DefaultConnection";
            var conStrSetting = ConfigurationManager.ConnectionStrings[conStrName];
            if (string.IsNullOrEmpty(conStrSetting?.ConnectionString))
                throw new ArgumentNullException("The 'DefaultConnection' connection string is absent or invalid");

            var demoConStrName = "DemoConnection";
            var demoConStrSetting = ConfigurationManager.ConnectionStrings[demoConStrName];
            if (string.IsNullOrEmpty(demoConStrSetting?.ConnectionString))
                throw new ArgumentNullException("The 'DemoConnection' connection string is absent or invalid");

            IContainer container = new Container(c => c.AddRegistry(new Composition(conStrSetting.ConnectionString, demoConStrSetting.ConnectionString)));

            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new StructureMapWebApiControllerActivator(container));

            //should be called before any other middleware
            //app.Use<CustomHeaderMiddleware>();

            ConfigureCORS(app);
            ConfigureOAuthTokenGeneration(app, container);
            ConfigureOAuthTokenConsumption(app);

            WebApiConfig.Register(config);

            config.EnsureInitialized();
        }


        private void ConfigureCORS(IAppBuilder app)
        {
            var policy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true
            };

            policy.Origins.Add("http://lmapp");

            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            });

        }

        
    }

    
}