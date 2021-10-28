namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvailableSeatsIdProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "ScreeningId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seats", "ScreeningId");
        }
    }
}
