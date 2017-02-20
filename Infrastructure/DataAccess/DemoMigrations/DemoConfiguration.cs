namespace DataAccess.DemoMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// use it like: add-migration <migrationName> -ConfigurationTypeName DemoConfiguration
    /// etc.
    /// </summary>
    internal sealed class DemoConfiguration : DbMigrationsConfiguration<DataAccess.Contexts.DemoLocalContext>
    {
        public DemoConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DemoMigrations";
        }

        protected override void Seed(DataAccess.Contexts.DemoLocalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
