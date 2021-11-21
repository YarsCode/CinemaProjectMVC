namespace CinemaProjectMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyChosenSeatsToOrderModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "NumberOfTicketsOrdered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "NumberOfTicketsOrdered", c => c.Int(nullable: false));
        }
    }
}
