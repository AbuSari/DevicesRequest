namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "PositionId", "dbo.Position");
            DropIndex("dbo.User", new[] { "PositionId" });
            AlterColumn("dbo.User", "FirstNameEn", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.User", "LastNameEn", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.User", "JobNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.User", "PositionId", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "UserEmail", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.User", "PositionId");
            AddForeignKey("dbo.User", "PositionId", "dbo.Position", "PositionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "PositionId", "dbo.Position");
            DropIndex("dbo.User", new[] { "PositionId" });
            AlterColumn("dbo.User", "UserEmail", c => c.String(maxLength: 100));
            AlterColumn("dbo.User", "PositionId", c => c.Int());
            AlterColumn("dbo.User", "JobNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.User", "LastNameEn", c => c.String(maxLength: 30));
            AlterColumn("dbo.User", "FirstNameEn", c => c.String(maxLength: 30));
            CreateIndex("dbo.User", "PositionId");
            AddForeignKey("dbo.User", "PositionId", "dbo.Position", "PositionId");
        }
    }
}
