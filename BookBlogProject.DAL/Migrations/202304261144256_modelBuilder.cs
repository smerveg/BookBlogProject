namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelBuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BookID", "dbo.Books");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "BookID" });
            AddColumn("dbo.Posts", "PersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Book_BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Category_CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Person_PersonID1", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Category_CategoryID1", c => c.Int());
            AddColumn("dbo.Posts", "Book_BookID1", c => c.Int());
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Book_BookID");
            CreateIndex("dbo.Posts", "Category_CategoryID");
            CreateIndex("dbo.Posts", "Person_PersonID1");
            CreateIndex("dbo.Posts", "Category_CategoryID1");
            CreateIndex("dbo.Posts", "Book_BookID1");
            AddForeignKey("dbo.Posts", "Book_BookID1", "dbo.Books", "BookID");
            AddForeignKey("dbo.Posts", "Category_CategoryID1", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "Book_BookID", "dbo.Books", "BookID");
            AddForeignKey("dbo.Posts", "Category_CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "Person_PersonID1", "dbo.People", "PersonID");
            DropColumn("dbo.Posts", "PersoneID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PersoneID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Posts", "Person_PersonID1", "dbo.People");
            DropForeignKey("dbo.Posts", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Book_BookID", "dbo.Books");
            DropForeignKey("dbo.Posts", "Category_CategoryID1", "dbo.Categories");
            DropForeignKey("dbo.Posts", "Book_BookID1", "dbo.Books");
            DropIndex("dbo.Posts", new[] { "Book_BookID1" });
            DropIndex("dbo.Posts", new[] { "Category_CategoryID1" });
            DropIndex("dbo.Posts", new[] { "Person_PersonID1" });
            DropIndex("dbo.Posts", new[] { "Category_CategoryID" });
            DropIndex("dbo.Posts", new[] { "Book_BookID" });
            AlterColumn("dbo.Posts", "CategoryID", c => c.Int());
            DropColumn("dbo.Posts", "Book_BookID1");
            DropColumn("dbo.Posts", "Category_CategoryID1");
            DropColumn("dbo.Posts", "Person_PersonID1");
            DropColumn("dbo.Posts", "Category_CategoryID");
            DropColumn("dbo.Posts", "Book_BookID");
            DropColumn("dbo.Posts", "PersonID");
            CreateIndex("dbo.Posts", "BookID");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "Person_PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
        }
    }
}
