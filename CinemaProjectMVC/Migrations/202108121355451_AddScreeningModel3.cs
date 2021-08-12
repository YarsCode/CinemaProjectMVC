namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScreeningModel3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Screenings", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Screenings", "Time", c => c.DateTime(nullable: false));
        }
    }
}
