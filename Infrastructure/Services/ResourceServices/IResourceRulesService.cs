using System;
using Entities;

namespace BusinessLogic.Links
{
    public interface IResourceRulesService
    {
        ResourceRule Create(Resource Resource, Rule Rule);
        ResourceRule Create(Guid LinkId, Guid RuleId);
    }
}