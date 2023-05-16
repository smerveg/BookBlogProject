namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BookID", "dbo.Books");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "PersonID", "dbo.People");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "BookID" });
            DropIndex("dbo.Posts", new[] { "PersonID" });
            AddColumn("dbo.Posts", "Person_PersonID", c => c.Int());
            AddColumn("dbo.Posts", "Category_CategoryID", c => c.Int());
            AddColumn("dbo.Posts", "Book_BookID", c => c.Int());
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "BookID", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryID");
            CreateIndex("dbo.Posts", "BookID");
            CreateIndex("dbo.Posts", "PersonID");
            CreateIndex("dbo.Posts", "Person_PersonID");
            CreateIndex("dbo.Posts", "Category_CategoryID");
            CreateIndex("dbo.Posts", "Book_BookID");
            AddForeignKey("dbo.Posts", "Book_BookID", "dbo.Books", "BookID");
            AddForeignKey("dbo.Posts", "Category_CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "Person_PersonID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Posts", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Book_BookID", "dbo.Books");
            DropIndex("dbo.Posts", new[] { "Book_BookID" });
            DropIndex("dbo.Posts", new[] { "Category_CategoryID" });
            DropIndex("dbo.Posts", new[] { "Person_PersonID" });
            DropIndex("dbo.Posts", new[] { "PersonID" });
            DropIndex("dbo.Posts", new[] { "BookID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            AlterColumn("dbo.Posts", "PersonID", c => c.Int());
            AlterColumn("dbo.Posts", "BookID", c => c.Int());
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int());
            DropColumn("dbo.Posts", "Book_BookID");
            DropColumn("dbo.Posts", "Category_CategoryID");
            DropColumn("dbo.Posts", "Person_PersonID");
            CreateIndex("dbo.Posts", "PersonID");
            CreateIndex("dbo.Posts", "BookID");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "BookID", "dbo.Books", "BookID");
        }
    }
}
