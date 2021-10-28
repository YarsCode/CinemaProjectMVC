namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatsIdProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cinemas", "SeatsId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cinemas", "SeatsId");
        }
    }
}
