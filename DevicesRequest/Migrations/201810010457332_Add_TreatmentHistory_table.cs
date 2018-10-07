namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_TreatmentHistory_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreatmentHistories",
                c => new
                    {
                        TreatmentHistoryId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StutusId = c.Int(),
                        RequestId = c.Int(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        RequestItem_RequestItemsId = c.Int(),
                        RequestStatu_RequestStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.TreatmentHistoryId)
                .ForeignKey("dbo.RequestItems", t => t.RequestItem_RequestItemsId)
                .ForeignKey("dbo.RequestStatus", t => t.RequestStatu_RequestStatusId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RequestItem_RequestItemsId)
                .Index(t => t.RequestStatu_RequestStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreatmentHistories", "UserId", "dbo.User");
            DropForeignKey("dbo.TreatmentHistories", "RequestStatu_RequestStatusId", "dbo.RequestStatus");
            DropForeignKey("dbo.TreatmentHistories", "RequestItem_RequestItemsId", "dbo.RequestItems");
            DropIndex("dbo.TreatmentHistories", new[] { "RequestStatu_RequestStatusId" });
            DropIndex("dbo.TreatmentHistories", new[] { "RequestItem_RequestItemsId" });
            DropIndex("dbo.TreatmentHistories", new[] { "UserId" });
            DropTable("dbo.TreatmentHistories");
        }
    }
}
