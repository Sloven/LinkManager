using System.Data.Entity;
using Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Contexts
{
    public abstract class AbstractDBContext : IdentityDbContext<ApplicationUser>
    {
        protected AbstractDBContext(string connectionStringName)
            : base(connectionStringName, throwIfV1Schema: false)
        { }

        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<ResourceRule> ResourceRules { get; set; }
        public virtual DbSet<ResourceAlias> ResourceAliases { get; set; }

    }
}
