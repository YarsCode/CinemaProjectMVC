namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateScreeningModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CinemaId = c.Byte(nullable: false),
                        MovieId = c.Byte(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Cinema_Id = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Cinema_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Screenings", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Screenings", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Screenings", new[] { "Movie_Id" });
            DropIndex("dbo.Screenings", new[] { "Cinema_Id" });
            DropTable("dbo.Screenings");
        }
    }
}
