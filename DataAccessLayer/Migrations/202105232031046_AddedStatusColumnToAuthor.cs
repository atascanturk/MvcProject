namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusColumnToAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Status");
        }
    }
}
