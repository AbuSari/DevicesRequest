namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Key_to_Shipment : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Shipment");
            AlterColumn("dbo.Shipment", "Quantity", c => c.Int());
            AlterColumn("dbo.Shipment", "ShipmentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Shipment", "ShipmentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Shipment");
            AlterColumn("dbo.Shipment", "ShipmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Shipment", "Quantity", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Shipment", "Quantity");
        }
    }
}
