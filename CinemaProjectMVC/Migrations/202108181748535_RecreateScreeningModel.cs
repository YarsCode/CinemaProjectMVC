namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateScreeningModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Screenings", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.Screenings", "MovieId", "dbo.Movies");
            DropIndex("dbo.Screenings", new[] { "CinemaId" });
            DropIndex("dbo.Screenings", new[] { "MovieId" });
            DropPrimaryKey("dbo.Cinemas");
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Cinemas", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cinemas", "Id");
            AddPrimaryKey("dbo.Movies", "Id");
            //DropTable("dbo.Screenings");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.Id);
            
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Cinemas");
            AlterColumn("dbo.Movies", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Cinemas", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Movies", "Id");
            AddPrimaryKey("dbo.Cinemas", "Id");
            CreateIndex("dbo.Screenings", "MovieId");
            CreateIndex("dbo.Screenings", "CinemaId");
            AddForeignKey("dbo.Screenings", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Screenings", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
    }
}
