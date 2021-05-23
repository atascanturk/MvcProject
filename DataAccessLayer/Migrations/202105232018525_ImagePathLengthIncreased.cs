namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathLengthIncreased : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "ImagePath", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "ImagePath", c => c.String(maxLength: 100));
        }
    }
}
