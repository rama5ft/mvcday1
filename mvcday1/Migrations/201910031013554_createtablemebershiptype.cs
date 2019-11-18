namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablemebershiptype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            DropColumn("dbo.Customers", "MemberShipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemberShipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MemberShipTypes", "Id", cascadeDelete: true);
        }
    }
}
