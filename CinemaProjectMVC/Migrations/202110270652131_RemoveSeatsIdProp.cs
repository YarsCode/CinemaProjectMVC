namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSeatsIdProp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cinemas", "SeatsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cinemas", "SeatsId", c => c.Byte(nullable: false));
        }
    }
}
