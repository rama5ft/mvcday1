namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumntoMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOVIEs", "AvailableStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MOVIEs", "AvailableStock");
        }
    }
}
