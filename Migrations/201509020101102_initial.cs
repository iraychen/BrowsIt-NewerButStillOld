namespace BROWSit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        PlatformID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlatformID);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 50),
                        Rationale = c.String(nullable: false, maxLength: 50),
                        PrefixID = c.Int(nullable: false),
                        TargetID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prefixes", t => t.PrefixID, cascadeDelete: true)
                .ForeignKey("dbo.Targets", t => t.TargetID, cascadeDelete: true)
                .Index(t => t.PrefixID)
                .Index(t => t.TargetID);
            
            CreateTable(
                "dbo.Prefixes",
                c => new
                    {
                        PrefixID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Document = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PrefixID);
            
            CreateTable(
                "dbo.Targets",
                c => new
                    {
                        TargetID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TargetID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Path = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TestID);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 50),
                        Query = c.String(nullable: false, maxLength: 200),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReportID);
            
            CreateTable(
                "dbo.RequirementPlatforms",
                c => new
                    {
                        Requirement_ID = c.Int(nullable: false),
                        Platform_PlatformID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Requirement_ID, t.Platform_PlatformID })
                .ForeignKey("dbo.Requirements", t => t.Requirement_ID, cascadeDelete: true)
                .ForeignKey("dbo.Platforms", t => t.Platform_PlatformID, cascadeDelete: true)
                .Index(t => t.Requirement_ID)
                .Index(t => t.Platform_PlatformID);
            
            CreateTable(
                "dbo.TestRequirements",
                c => new
                    {
                        Test_TestID = c.Int(nullable: false),
                        Requirement_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_TestID, t.Requirement_ID })
                .ForeignKey("dbo.Tests", t => t.Test_TestID, cascadeDelete: true)
                .ForeignKey("dbo.Requirements", t => t.Requirement_ID, cascadeDelete: true)
                .Index(t => t.Test_TestID)
                .Index(t => t.Requirement_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestRequirements", "Requirement_ID", "dbo.Requirements");
            DropForeignKey("dbo.TestRequirements", "Test_TestID", "dbo.Tests");
            DropForeignKey("dbo.Requirements", "TargetID", "dbo.Targets");
            DropForeignKey("dbo.Requirements", "PrefixID", "dbo.Prefixes");
            DropForeignKey("dbo.RequirementPlatforms", "Platform_PlatformID", "dbo.Platforms");
            DropForeignKey("dbo.RequirementPlatforms", "Requirement_ID", "dbo.Requirements");
            DropIndex("dbo.TestRequirements", new[] { "Requirement_ID" });
            DropIndex("dbo.TestRequirements", new[] { "Test_TestID" });
            DropIndex("dbo.RequirementPlatforms", new[] { "Platform_PlatformID" });
            DropIndex("dbo.RequirementPlatforms", new[] { "Requirement_ID" });
            DropIndex("dbo.Requirements", new[] { "TargetID" });
            DropIndex("dbo.Requirements", new[] { "PrefixID" });
            DropTable("dbo.TestRequirements");
            DropTable("dbo.RequirementPlatforms");
            DropTable("dbo.Reports");
            DropTable("dbo.Tests");
            DropTable("dbo.Targets");
            DropTable("dbo.Prefixes");
            DropTable("dbo.Requirements");
            DropTable("dbo.Platforms");
        }
    }
}
