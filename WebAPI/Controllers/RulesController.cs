using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
//using System.Web;
using System.Web.Http;
using Services.Resources;
using Microsoft.Owin;

namespace WebAPI.Controllers
{
    [Authorize]
    public class RulesController : ApiController
    {
        private IRulesService rs;// = RulesBR.Instance;

        public RulesController(IRulesService _rs)
        {
            if(_rs == null)
                throw new NotImplementedException("Rules service is not implemented");

            rs = _rs;
        }

        // GET: api/Rules
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rules/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rules
        public void Post(string Name, string Description)
        {
            rs.Add(Name, Description);
        }

        // PUT: api/Rules/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rules/5
        public void Delete(int id)
        {
        }
    }
}
