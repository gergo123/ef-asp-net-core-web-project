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
                "dbo.SecurityIdentities",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    FullName = c.String(),
                    Email = c.String(),
                    Identifier = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SecurityGroups",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SecurityGroupSecurityIdentities",
                c => new
                {
                    SecurityGroup_Id = c.Long(nullable: false),
                    SecurityIdentity_Id = c.Long(nullable: false),
                })
                .PrimaryKey(t => new { t.SecurityGroup_Id, t.SecurityIdentity_Id })
                .ForeignKey("dbo.SecurityGroups", t => t.SecurityGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.SecurityIdentities", t => t.SecurityIdentity_Id, cascadeDelete: true)
                .Index(t => t.SecurityGroup_Id)
                .Index(t => t.SecurityIdentity_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.SecurityGroupSecurityIdentities", "SecurityIdentity_Id", "dbo.SecurityIdentities");
            DropForeignKey("dbo.SecurityGroupSecurityIdentities", "SecurityGroup_Id", "dbo.SecurityGroups");
            DropIndex("dbo.SecurityGroupSecurityIdentities", new[] { "SecurityIdentity_Id" });
            DropIndex("dbo.SecurityGroupSecurityIdentities", new[] { "SecurityGroup_Id" });
            DropTable("dbo.SecurityGroupSecurityIdentities");
            DropTable("dbo.SecurityGroups");
            DropTable("dbo.SecurityIdentities");
            DropTable("dbo.PlaceholderEntityACLs");
            DropTable("dbo.PlaceholderEntities");
        }
    }
}
