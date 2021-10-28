namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteScreeningIdFromSeatModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Seats", "ScreeningId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "ScreeningId", c => c.Byte(nullable: false));
        }
    }
}
