using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Services;
using Services.Resources;
using DataAccess;

namespace WebAPI.Controllers
{
    [Authorize]
    public class ResourceRulesController : ApiController
    {
        private IResourceRulesService lrs;

        public ResourceRulesController(IResourceRulesService lrService)
        {
            if(lrService == null)
                throw new NullReferenceException("ResourceRuleService is not defined");

            lrs = lrService;
            //var context = HttpContext.Current.GetOwinContext().Get<EFDBContext>(typeof(EFDBContext).ToString());
            //lrbr = new LinkRulesBR(context);
        }
         
        // GET: api/ResourceRule
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LinkRules/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LinkRules
        public void Post(Guid LinkId, Guid RuleId)
        {

            lrs.Create(LinkId, RuleId);
        }

        // PUT: api/LinkRules/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LinkRules/5
        public void Delete(int id)
        {
        }
    }
}
