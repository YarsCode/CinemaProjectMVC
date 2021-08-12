namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScreeningModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screenings", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Screenings", "Time");
        }
    }
}
