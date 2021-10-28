namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSeatModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            DropTable("dbo.Seats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CinemaId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        isAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Seats", "CinemaId");
            AddForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
    }
}
