using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using DataAccess;
using Entities;
using Microsoft.ApplicationInsights.WindowsServer;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using BusinessLogic;
using BusinessLogic.Links;

namespace WebAPI.Controllers
{
    [System.Web.Http.Authorize]
    [RoutePrefix("api/resources")]
    public class ResourcesController: ApiController
    {
        private IResourcesService _ls;
        public virtual string CurrentUserId => User.Identity.GetUserId();
        public virtual string CurrentUserName => User.Identity.Name;

        [NonAction]
        public virtual HttpResponseMessage PrepareResponse(HttpStatusCode statusCode, string value)
        {
            return Request.CreateResponse(statusCode, value);
        }

        public ResourcesController(IResourcesService ls)
        {
            if(ls == null)
                throw new ArgumentNullException("LinkService is not implemented");

            _ls = ls;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Resource> Get()
        {
            try
            {
                return _ls.GetAll(CurrentUserName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("public")]//"/{userName}")]
        //public IEnumerable<Resource> Public([FromBody]string userName)
        public IEnumerable<Resource> Public(dynamic userName)
        {
            string uname = userName;
            try
            {
                return _ls.GetAll(uname);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        // POST api/resources
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string URL)
        {
            if(string.IsNullOrEmpty(URL))
                return PrepareResponse(HttpStatusCode.BadRequest, "Wrong URL");
            
            _ls.AddLink(CurrentUserId, URL);
            return PrepareResponse(HttpStatusCode.OK, "");
        }


        
    }
}
