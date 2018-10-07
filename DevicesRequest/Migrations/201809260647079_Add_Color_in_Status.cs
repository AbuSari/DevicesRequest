namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Color_in_Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestStatus", "Color", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestStatus", "Color");
        }
    }
}
