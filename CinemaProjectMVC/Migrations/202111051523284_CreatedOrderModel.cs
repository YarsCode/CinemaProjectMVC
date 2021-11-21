namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedOrderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScreeningId = c.Int(nullable: false),
                        NumberOfTicketsOrdered = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Screenings", t => t.ScreeningId, cascadeDelete: true)
                .Index(t => t.ScreeningId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ScreeningId", "dbo.Screenings");
            DropIndex("dbo.Orders", new[] { "ScreeningId" });
            DropTable("dbo.Orders");
        }
    }
}
