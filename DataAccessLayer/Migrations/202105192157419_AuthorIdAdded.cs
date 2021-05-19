namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorIdAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Titles", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Titles", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Titles", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.Titles", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Titles", "AuthorId");
            AddForeignKey("dbo.Titles", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Titles", new[] { "AuthorId" });
            AlterColumn("dbo.Titles", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Titles", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Titles", "Author_Id");
            AddForeignKey("dbo.Titles", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
