namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceAliases",
                c => new
                    {
                        AliasId = c.Long(nullable: false, identity: true),
                        Alias = c.String(nullable: false),
                        HiPrefix = c.String(),
                        LowPrefix = c.String(),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                        Resource_ResourceId = c.Guid(),
                    })
                .PrimaryKey(t => t.AliasId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceId)
                .Index(t => t.UserId)
                .Index(t => t.Resource_ResourceId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Guid(nullable: false, identity: true),
                        URL = c.String(),
                        Title = c.String(),
                        CreatedAt = c.DateTime(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ResourceRules",
                c => new
                    {
                        ResourceRuleId = c.Guid(nullable: false, identity: true),
                        Resource_ResourceId = c.Guid(),
                        Rule_RuleId = c.Guid(),
                    })
                .PrimaryKey(t => t.ResourceRuleId)
                .ForeignKey("dbo.Resources", t => t.Resource_ResourceId)
                .ForeignKey("dbo.Rules", t => t.Rule_RuleId)
                .Index(t => t.Resource_ResourceId)
                .Index(t => t.Rule_RuleId);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        RuleId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RuleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ResourceAliases", "Resource_ResourceId", "dbo.Resources");
            DropForeignKey("dbo.ResourceRules", "Rule_RuleId", "dbo.Rules");
            DropForeignKey("dbo.ResourceRules", "Resource_ResourceId", "dbo.Resources");
            DropForeignKey("dbo.Resources", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ResourceAliases", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ResourceRules", new[] { "Rule_RuleId" });
            DropIndex("dbo.ResourceRules", new[] { "Resource_ResourceId" });
            DropIndex("dbo.Resources", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ResourceAliases", new[] { "Resource_ResourceId" });
            DropIndex("dbo.ResourceAliases", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rules");
            DropTable("dbo.ResourceRules");
            DropTable("dbo.Resources");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ResourceAliases");
        }
    }
}
