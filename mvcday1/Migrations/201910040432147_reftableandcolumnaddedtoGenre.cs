namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reftableandcolumnaddedtoGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOVIEs", "GenreId", c => c.Int(nullable: true));
            CreateIndex("dbo.MOVIEs", "GenreId");
            AddForeignKey("dbo.MOVIEs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MOVIEs", "GenreId", "dbo.Genres");
            DropIndex("dbo.MOVIEs", new[] { "GenreId" });
            DropColumn("dbo.MOVIEs", "GenreId");
        }
    }
}
