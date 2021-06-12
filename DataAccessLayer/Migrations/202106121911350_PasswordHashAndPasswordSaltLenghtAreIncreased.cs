namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordHashAndPasswordSaltLenghtAreIncreased : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "PasswordSalt", c => c.Binary(maxLength: 750));
            AlterColumn("dbo.Admins", "PasswordHash", c => c.Binary(maxLength: 750));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "PasswordHash", c => c.Binary(maxLength: 500));
            AlterColumn("dbo.Admins", "PasswordSalt", c => c.Binary(maxLength: 500));
        }
    }
}
