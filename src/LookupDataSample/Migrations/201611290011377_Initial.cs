namespace LookupDataSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DefaultStyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeatureStyle",
                c => new
                    {
                        FeatureId = c.Int(nullable: false),
                        StyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FeatureId, t.StyleId })
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.StyleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeatureStyle", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.FeatureStyle", "FeatureId", "dbo.Features");
            DropIndex("dbo.FeatureStyle", new[] { "StyleId" });
            DropIndex("dbo.FeatureStyle", new[] { "FeatureId" });
            DropTable("dbo.FeatureStyle");
            DropTable("dbo.Styles");
            DropTable("dbo.Features");
        }
    }
}
