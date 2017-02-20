using Entities;

namespace BusinessLogic.Links
{
    public interface IRulesService
    {
        void Add(string name, string description);
        void Add(Rule rule);
        Rule GetFirst();
    }
}