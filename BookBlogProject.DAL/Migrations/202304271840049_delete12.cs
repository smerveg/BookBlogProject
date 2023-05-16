namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete12 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Book_BookID", newName: "BookID");
            RenameColumn(table: "dbo.Posts", name: "Category_CategoryID", newName: "CategoryID");
            RenameColumn(table: "dbo.Posts", name: "Person_PersonID", newName: "PersonID");
            RenameIndex(table: "dbo.Posts", name: "IX_Category_CategoryID", newName: "IX_CategoryID");
            RenameIndex(table: "dbo.Posts", name: "IX_Book_BookID", newName: "IX_BookID");
            RenameIndex(table: "dbo.Posts", name: "IX_Person_PersonID", newName: "IX_PersonID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_PersonID", newName: "IX_Person_PersonID");
            RenameIndex(table: "dbo.Posts", name: "IX_BookID", newName: "IX_Book_BookID");
            RenameIndex(table: "dbo.Posts", name: "IX_CategoryID", newName: "IX_Category_CategoryID");
            RenameColumn(table: "dbo.Posts", name: "PersonID", newName: "Person_PersonID");
            RenameColumn(table: "dbo.Posts", name: "CategoryID", newName: "Category_CategoryID");
            RenameColumn(table: "dbo.Posts", name: "BookID", newName: "Book_BookID");
        }
    }
}
