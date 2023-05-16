namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAuthor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorID" });
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_BookID = c.Int(nullable: false),
                        Author_AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_BookID, t.Author_AuthorID })
                .ForeignKey("dbo.Books", t => t.Book_BookID, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorID, cascadeDelete: true)
                .Index(t => t.Book_BookID)
                .Index(t => t.Author_AuthorID);
            
            DropColumn("dbo.Books", "AuthorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AuthorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookAuthors", "Author_AuthorID", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BookID", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_AuthorID" });
            DropIndex("dbo.BookAuthors", new[] { "Book_BookID" });
            DropTable("dbo.BookAuthors");
            CreateIndex("dbo.Books", "AuthorID");
            AddForeignKey("dbo.Books", "AuthorID", "dbo.Authors", "AuthorID", cascadeDelete: true);
        }
    }
}
