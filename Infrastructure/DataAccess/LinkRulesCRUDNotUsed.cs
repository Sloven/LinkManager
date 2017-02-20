using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstractions;
using DataAccess.Contexts;
using Entities;

namespace DataAccess
{
    public class LinkRulesCRUDNotUsed: BasicCRUD<ResourceRule>
    {
        public LinkRulesCRUDNotUsed(AbstractDBContext context):base(context) {}

        public ResourceRule Create(Guid LinkId, Guid RuleId)
        {
            var lnk = base.db.Resources.FirstOrDefault(l => l.ResourceId == LinkId);
            var rl = base.db.Rules.FirstOrDefault(r => r.RuleId == RuleId);
            var lnkr = new ResourceRule() {Resource = lnk, Rule = rl};

            base.Add(lnkr);

            return lnkr;
        }
    }
}
