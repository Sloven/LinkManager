using System;
using Entities;

namespace Services.Resources
{
    public interface IResourceRulesService
    {
        ResourceRule Create(Resource Resource, Rule Rule);
        ResourceRule Create(Guid LinkId, Guid RuleId);
    }
}