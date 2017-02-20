using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusinessLogic.Links;
using DataAccess;
using DataAccess.Abstractions;
using DataAccess.Contexts;
using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using StructureMap;
using StructureMap.Web.Pipeline;

namespace WebAPI.DependencyResolution
{
    public class Composition: Registry
    {
        public Composition(string defaultConnectionString, string demoConnectionString)
        {
            For<IBasicCRUD<Resource>>().Use<BasicCRUD<Resource>>();
            For<IBasicCRUD<ResourceRule>>().Use<BasicCRUD<ResourceRule>>();
            For<IBasicCRUD<Rule>>().Use<BasicCRUD<Rule>>();

            For<IDBLookup<ApplicationUser>>().Use<BasicCRUD<ApplicationUser>>();

            For<IResourcesService>().Use<ResourceService>();
            For<IResourceRulesService>().Use<ResourceRulesService>();
            For<IRulesService>().Use<RulesService>();

            For<OWINDBContext>().Use(() => new OWINDBContext(defaultConnectionString));
            For<DemoOWINDBContext>().Use(() => new DemoOWINDBContext(demoConnectionString));

            this.Profile("appProfile", p =>
            {
                p.For<AbstractDBContext>().Use<EFDBContext>().Ctor<string>().Is(defaultConnectionString); 
            });

            this.Profile("demoProfile", p =>
            {
                p.For<AbstractDBContext>().Use<EFDBContext>().Ctor<string>().Is(demoConnectionString);
            });
        }
    }
}