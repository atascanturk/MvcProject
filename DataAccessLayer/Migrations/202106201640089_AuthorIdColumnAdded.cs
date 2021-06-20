namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorIdColumnAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Contents", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Contents", name: "Author_Id", newName: "AuthorId");           
            CreateIndex("dbo.Contents", "AuthorId");
            AddForeignKey("dbo.Contents", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Contents", new[] { "AuthorId" });
            AlterColumn("dbo.Contents", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Contents", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Contents", "Author_Id");
            AddForeignKey("dbo.Contents", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
