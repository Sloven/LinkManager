using Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Contexts
{
    public class OWINDBContext : IdentityDbContext<ApplicationUser>
    {
        public OWINDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString, throwIfV1Schema: false)
        {
        }

    }
}
