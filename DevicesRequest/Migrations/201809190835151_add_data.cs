namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Building",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                        BuildingId = c.Int(),
                    })
                .PrimaryKey(t => t.LevelId)
                .ForeignKey("dbo.Building", t => t.BuildingId)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstNameAr = c.String(maxLength: 30),
                        LastNameAr = c.String(maxLength: 30),
                        FirstNameEn = c.String(maxLength: 30),
                        LastNameEn = c.String(maxLength: 30),
                        JobNumber = c.String(maxLength: 15),
                        LevelId = c.Int(),
                        DepartmentId = c.Int(),
                        PositionId = c.Int(),
                        RoomNo = c.String(maxLength: 15),
                        Telephon = c.String(maxLength: 15),
                        Mobile = c.String(maxLength: 15),
                        UserEmail = c.String(maxLength: 100),
                        CereatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        ImageJobNo = c.String(),
                        Comment = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .ForeignKey("dbo.Position", t => t.PositionId)
                .Index(t => t.LevelId)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        ParentId = c.Int(),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        ManagerId = c.Int(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Department", t => t.ParentId)
                .ForeignKey("dbo.User", t => t.ManagerId)
                .Index(t => t.ParentId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                        NeedApproved = c.Boolean(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.RequestItems",
                c => new
                    {
                        RequestItemsId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Quantity = c.Int(),
                        RequestDate = c.DateTime(),
                        StutusId = c.Int(),
                        TypeOfRequestId = c.Int(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        DirectorRecommondation = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.RequestItemsId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .ForeignKey("dbo.RequestStatus", t => t.StutusId)
                .ForeignKey("dbo.TypeOfRequest", t => t.TypeOfRequestId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.ItemId)
                .Index(t => t.UserId)
                .Index(t => t.StutusId)
                .Index(t => t.TypeOfRequestId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                        UnitsInStock = c.Int(),
                        UnitsOnOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        ShipmentId = c.Int(nullable: false),
                        PoRceivedId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ShipmentId)
                .ForeignKey("dbo.PoRceived", t => t.PoRceivedId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.PoRceivedId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.PoRceived",
                c => new
                    {
                        PoRceivedId = c.Int(nullable: false, identity: true),
                        CompanyNameEn = c.String(maxLength: 100),
                        CompanyNameAr = c.String(maxLength: 100),
                        PoCode = c.String(maxLength: 50),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.PoRceivedId);
            
            CreateTable(
                "dbo.RequestStatus",
                c => new
                    {
                        RequestStatusId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        StatusCode = c.String(maxLength: 10),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.RequestStatusId);
            
            CreateTable(
                "dbo.TechnicianReport",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                        ReportItem = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReportId)
                .ForeignKey("dbo.RequestItems", t => t.ReportItem)
                .Index(t => t.ReportItem);
            
            CreateTable(
                "dbo.TypeOfRequest",
                c => new
                    {
                        TypeOfRequestId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.TypeOfRequestId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.String(maxLength: 100),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.String(maxLength: 100),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        NameEn = c.String(maxLength: 100),
                        NameAr = c.String(maxLength: 100),
                        CreatedBy = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(),
                        LastUpdateBy = c.String(maxLength: 100),
                        LastUpdateDate = c.DateTime(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RequestItems", "UserId", "dbo.User");
            DropForeignKey("dbo.RequestItems", "TypeOfRequestId", "dbo.TypeOfRequest");
            DropForeignKey("dbo.TechnicianReport", "ReportItem", "dbo.RequestItems");
            DropForeignKey("dbo.RequestItems", "StutusId", "dbo.RequestStatus");
            DropForeignKey("dbo.Shipment", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Shipment", "PoRceivedId", "dbo.PoRceived");
            DropForeignKey("dbo.RequestItems", "ItemId", "dbo.Item");
            DropForeignKey("dbo.User", "PositionId", "dbo.Position");
            DropForeignKey("dbo.User", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Department", "ManagerId", "dbo.User");
            DropForeignKey("dbo.User", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "ParentId", "dbo.Department");
            DropForeignKey("dbo.Level", "BuildingId", "dbo.Building");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.TechnicianReport", new[] { "ReportItem" });
            DropIndex("dbo.Shipment", new[] { "ItemId" });
            DropIndex("dbo.Shipment", new[] { "PoRceivedId" });
            DropIndex("dbo.RequestItems", new[] { "TypeOfRequestId" });
            DropIndex("dbo.RequestItems", new[] { "StutusId" });
            DropIndex("dbo.RequestItems", new[] { "UserId" });
            DropIndex("dbo.RequestItems", new[] { "ItemId" });
            DropIndex("dbo.Department", new[] { "ManagerId" });
            DropIndex("dbo.Department", new[] { "ParentId" });
            DropIndex("dbo.User", new[] { "PositionId" });
            DropIndex("dbo.User", new[] { "DepartmentId" });
            DropIndex("dbo.User", new[] { "LevelId" });
            DropIndex("dbo.Level", new[] { "BuildingId" });
            DropTable("dbo.Role");
            DropTable("dbo.UserRoles");
            DropTable("dbo.TypeOfRequest");
            DropTable("dbo.TechnicianReport");
            DropTable("dbo.RequestStatus");
            DropTable("dbo.PoRceived");
            DropTable("dbo.Shipment");
            DropTable("dbo.Item");
            DropTable("dbo.RequestItems");
            DropTable("dbo.Position");
            DropTable("dbo.Department");
            DropTable("dbo.User");
            DropTable("dbo.Level");
            DropTable("dbo.Building");
        }
    }
}
