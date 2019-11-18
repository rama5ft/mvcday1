namespace mvcday1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres(Name) values('family Entertainer')");
            Sql("Insert Genres(Name) values('Horror')");
            Sql("Insert Genres(Name) values('Revenge')");
            Sql("Insert Genres(Name) values('Crime')");
            Sql("Insert Genres(Name) values('Love')");
        }
        
        public override void Down()
        {
        }
    }
}
