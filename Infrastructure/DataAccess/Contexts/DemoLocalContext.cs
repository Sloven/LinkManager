using DataAccess.Abstractions;

namespace DataAccess.Contexts
{
    public class DemoLocalContext : AbstractDBContext
    {
        public DemoLocalContext() : base("DemoConnection")
        {
        }
    }
}
