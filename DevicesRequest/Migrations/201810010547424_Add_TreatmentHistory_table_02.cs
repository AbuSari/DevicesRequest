namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_TreatmentHistory_table_02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TreatmentHistories", "StutusId", c => c.Int(nullable: false));
            AlterColumn("dbo.TreatmentHistories", "RequestId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TreatmentHistories", "RequestId", c => c.Int());
            AlterColumn("dbo.TreatmentHistories", "StutusId", c => c.Int());
        }
    }
}
