namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedAvailableSeatsIdProp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Screenings", "AvailableSeatsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Screenings", "AvailableSeatsId", c => c.Byte(nullable: false));
        }
    }
}
