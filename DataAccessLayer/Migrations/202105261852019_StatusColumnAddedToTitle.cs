namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusColumnAddedToTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Titles", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Titles", "Status");
        }
    }
}
