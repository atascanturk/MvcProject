namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Title", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Title");
        }
    }
}
