namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_requredPosition01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "PositionId", "dbo.Position");
            DropIndex("dbo.User", new[] { "PositionId" });
            AlterColumn("dbo.User", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "PositionId");
            AddForeignKey("dbo.User", "PositionId", "dbo.Position", "PositionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "PositionId", "dbo.Position");
            DropIndex("dbo.User", new[] { "PositionId" });
            AlterColumn("dbo.User", "PositionId", c => c.Int());
            CreateIndex("dbo.User", "PositionId");
            AddForeignKey("dbo.User", "PositionId", "dbo.Position", "PositionId");
        }
    }
}
