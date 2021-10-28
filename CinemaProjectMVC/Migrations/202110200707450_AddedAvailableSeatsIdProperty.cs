namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvailableSeatsIdProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screenings", "AvailableSeatsId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Screenings", "AvailableSeatsId");
        }
    }
}
