namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.Posts", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Person_PersonID1", "dbo.People");
            DropIndex("dbo.Posts", new[] { "Book_BookID" });
            DropIndex("dbo.Posts", new[] { "Category_CategoryID" });
            DropIndex("dbo.Posts", new[] { "Person_PersonID1" });
            DropIndex("dbo.Posts", new[] { "Category_CategoryID1" });
            DropIndex("dbo.Posts", new[] { "Book_BookID1" });
            DropColumn("dbo.Posts", "Book_BookID");
            DropColumn("dbo.Posts", "Category_CategoryID");
            RenameColumn(table: "dbo.Posts", name: "Book_BookID1", newName: "Book_BookID");
            RenameColumn(table: "dbo.Posts", name: "Category_CategoryID1", newName: "Category_CategoryID");
            AlterColumn("dbo.Posts", "Book_BookID", c => c.Int());
            AlterColumn("dbo.Posts", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.Posts", "Category_CategoryID");
            CreateIndex("dbo.Posts", "Book_BookID");
            DropColumn("dbo.Posts", "CategoryID");
            DropColumn("dbo.Posts", "BookID");
            DropColumn("dbo.Posts", "PersonID");
            DropColumn("dbo.Posts", "Person_PersonID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Person_PersonID1", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "PersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            DropIndex("dbo.Posts", new[] { "Book_BookID" });
            DropIndex("dbo.Posts", new[] { "Category_CategoryID" });
            AlterColumn("dbo.Posts", "Category_CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Book_BookID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Posts", name: "Category_CategoryID", newName: "Category_CategoryID1");
            RenameColumn(table: "dbo.Posts", name: "Book_BookID", newName: "Book_BookID1");
            AddColumn("dbo.Posts", "Category_CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Book_BookID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Book_BookID1");
            CreateIndex("dbo.Posts", "Category_CategoryID1");
            CreateIndex("dbo.Posts", "Person_PersonID1");
            CreateIndex("dbo.Posts", "Category_CategoryID");
            CreateIndex("dbo.Posts", "Book_BookID");
            AddForeignKey("dbo.Posts", "Person_PersonID1", "dbo.People", "PersonID");
            AddForeignKey("dbo.Posts", "Category_CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "Book_BookID", "dbo.Books", "BookID");
        }
    }
}
