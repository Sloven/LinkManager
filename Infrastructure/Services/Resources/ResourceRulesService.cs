using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstractions;
using Entities;

namespace Services.Resources
{
    public class ResourceRulesService: IResourceRulesService
    {
        private IBasicCRUD<ResourceRule> CRUD { get; }
        private IDBLookup<Resource> LinkLookup { get; }
        private IDBLookup<Rule> RuleLookup { get; }

        public ResourceRulesService(IBasicCRUD<ResourceRule> _CRUD, IDBLookup<Resource> _LinkLookup, IDBLookup<Rule> _RuleLookup)
        {
            CRUD = _CRUD;
            LinkLookup = _LinkLookup;
            RuleLookup = _RuleLookup;
        }

        public ResourceRule Create(Resource resource, Rule rule)
        {
            var lnk = LinkLookup.First(l => l.ResourceId == resource.ResourceId);
            if (lnk == null) return null;

            var rl = RuleLookup.First(r => r.RuleId == rule.RuleId);
            if (rl == null) return null;

            var lnkr = new ResourceRule() { Resource = lnk, Rule = rl };
            CRUD.Add(lnkr);

            return lnkr;
        }

        /// <summary>
        /// Join existant Resources and Rules
        /// </summary>
        /// <param name="LinkId"></param>
        /// <param name="RuleId"></param>
        /// <returns></returns>
        public ResourceRule Create(Guid LinkId, Guid RuleId)
        {
            return Create(new Resource() {ResourceId = LinkId}, new Rule() {RuleId = RuleId});
        }
    }
}
