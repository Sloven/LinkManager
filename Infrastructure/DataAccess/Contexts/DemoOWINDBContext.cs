using Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Contexts
{
    public class DemoOWINDBContext : IdentityDbContext<ApplicationUser>
    {
        public DemoOWINDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString, throwIfV1Schema: false)
        {
        }

    }
}
