using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using DataAccess.Contexts;
using StructureMap;

namespace WebAPI.DependencyResolution
{
    public class StructureMapWebApiControllerActivator : IHttpControllerActivator
    {
        private readonly IContainer _container;

        public StructureMapWebApiControllerActivator(IContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request,HttpControllerDescriptor controllerDescriptor,Type controllerType)
        {
            var nested = defineContainer(request);
            var instance = nested.GetInstance(controllerType) as IHttpController;
            request.RegisterForDispose(nested);
            return instance;
        }

        private IContainer defineContainer(HttpRequestMessage request)
        {
            if (request.Headers.Contains("isDemo"))
                return _container.GetProfile("demoProfile").GetNestedContainer();
            else
                return _container.GetProfile("appProfile").GetNestedContainer();
        }
    }
}
