using DataAccess.Abstractions;

namespace DataAccess.Contexts
{
    public class EFDBContext : AbstractDBContext
    {
        public EFDBContext(string connectionStringName) : base(connectionStringName)
        {
        }
    }
}
