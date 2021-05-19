namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAboutColumnAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Contents", new[] { "AuthorId" });
            RenameColumn(table: "dbo.Contents", name: "AuthorId", newName: "Author_Id");
            AddColumn("dbo.Authors", "About", c => c.String(maxLength: 100));
            AlterColumn("dbo.Authors", "Mail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Authors", "Password", c => c.String(maxLength: 200));
            AlterColumn("dbo.Contents", "Author_Id", c => c.Int());
            CreateIndex("dbo.Contents", "Author_Id");
            AddForeignKey("dbo.Contents", "Author_Id", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Contents", new[] { "Author_Id" });
            AlterColumn("dbo.Contents", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.Authors", "Mail", c => c.String(maxLength: 50));
            DropColumn("dbo.Authors", "About");
            RenameColumn(table: "dbo.Contents", name: "Author_Id", newName: "AuthorId");
            CreateIndex("dbo.Contents", "AuthorId");
            AddForeignKey("dbo.Contents", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
