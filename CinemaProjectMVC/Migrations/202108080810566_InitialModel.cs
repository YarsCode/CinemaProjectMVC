namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                        ScreeningTime_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScreeningTimes", t => t.ScreeningTime_Id, cascadeDelete: true)
                .Index(t => t.ScreeningTime_Id);
            
            CreateTable(
                "dbo.ScreeningTimes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Time = c.String(nullable: false, maxLength: 255),
                        isAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DurationInMinutes = c.Int(nullable: false),
                        Rating_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.Rating_Id)
                .Index(t => t.GenreId)
                .Index(t => t.Rating_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Rating_Id", "dbo.Ratings");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Cinemas", "ScreeningTime_Id", "dbo.ScreeningTimes");
            DropIndex("dbo.Movies", new[] { "Rating_Id" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Cinemas", new[] { "ScreeningTime_Id" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.ScreeningTimes");
            DropTable("dbo.Cinemas");
        }
    }
}
