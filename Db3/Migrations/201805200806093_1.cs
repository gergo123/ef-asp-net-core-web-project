namespace Db3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceholderEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaceholderEntityACLs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        EntityID = c.Long(nullable: false),
                        Permission = c.Int(nullable: false),
                        SecurityObjectID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SecurityObjects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Identifier = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimplePlaceHolderEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SimpleProperty = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecurityIdentitySecurityGroups",
                c => new
                    {
                        SecurityIdentity_Id = c.Long(nullable: false),
                        SecurityGroup_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.SecurityIdentity_Id, t.SecurityGroup_Id })
                .ForeignKey("dbo.SecurityObjects", t => t.SecurityIdentity_Id)
                .ForeignKey("dbo.SecurityObjects", t => t.SecurityGroup_Id)
                .Index(t => t.SecurityIdentity_Id)
                .Index(t => t.SecurityGroup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityIdentitySecurityGroups", "SecurityGroup_Id", "dbo.SecurityObjects");
            DropForeignKey("dbo.SecurityIdentitySecurityGroups", "SecurityIdentity_Id", "dbo.SecurityObjects");
            DropIndex("dbo.SecurityIdentitySecurityGroups", new[] { "SecurityGroup_Id" });
            DropIndex("dbo.SecurityIdentitySecurityGroups", new[] { "SecurityIdentity_Id" });
            DropTable("dbo.SecurityIdentitySecurityGroups");
            DropTable("dbo.SimplePlaceHolderEntities");
            DropTable("dbo.SecurityObjects");
            DropTable("dbo.PlaceholderEntityACLs");
            DropTable("dbo.PlaceholderEntities");
        }
    }
}
