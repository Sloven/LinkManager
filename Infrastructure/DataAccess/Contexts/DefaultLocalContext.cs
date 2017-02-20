using DataAccess.Abstractions;

namespace DataAccess.Contexts
{
    public class DefaultLocalContext : AbstractDBContext
    {
        public DefaultLocalContext() : base("DefaultConnection")
        {
        }
    }
}
