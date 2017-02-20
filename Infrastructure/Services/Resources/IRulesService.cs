using Entities;

namespace Services.Resources
{
    public interface IRulesService
    {
        void Add(string name, string description);
        void Add(Rule rule);
        Rule GetFirst();
    }
}