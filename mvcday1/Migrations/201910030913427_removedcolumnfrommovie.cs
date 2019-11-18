namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcolumnfrommovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MOVIEs", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MOVIEs", "Genre", c => c.String());
        }
    }
}
