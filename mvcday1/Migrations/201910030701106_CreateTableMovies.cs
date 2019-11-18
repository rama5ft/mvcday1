namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MOVIEs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Moviename = c.String(),
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MOVIEs");
        }
    }
}
