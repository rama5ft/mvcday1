namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reftableandcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Int(nullable: true));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            DropColumn("dbo.Customers", "MemberShipTypeId");
        }
    }
}
