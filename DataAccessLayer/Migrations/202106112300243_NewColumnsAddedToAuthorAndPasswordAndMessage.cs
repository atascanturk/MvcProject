namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnsAddedToAuthorAndPasswordAndMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary(maxLength: 500));
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary(maxLength: 500));
            AddColumn("dbo.Messages", "isSeen", c => c.Boolean(nullable: false));
            DropColumn("dbo.Admins", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Password", c => c.String(maxLength: 50));
            DropColumn("dbo.Messages", "isSeen");
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
            DropColumn("dbo.Abouts", "isActive");
        }
    }
}
