namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatModel2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .Index(t => t.CinemaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "CinemaId" });
            DropTable("dbo.Seats");
        }
    }
}
