using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Links;
using DataAccess;
using DataAccess.Abstractions;
using Entities;

namespace BusinessLogic.Links
{
    public class RulesService: AbstractBasicService<Rule>, IRulesService
    {
        public RulesService(IBasicCRUD<Rule> basicCrud) : base(basicCrud) { }

        public void Add(string name, string description)
        {
            var r = new Rule() {Name= name, Description = description};
            Add(r);
        }

        public void Add(Rule rule)
        {
            CRUD.Add(rule);
        }

        public Rule GetFirst()
        {
            return CRUD.First(null);
        }

    }
}
