namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookDuzeltmeler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ReleaseYear", c => c.Int());
            AlterColumn("dbo.Books", "PageCount", c => c.Int());
            DropColumn("dbo.Books", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "PageCount", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "ReleaseYear");
        }
    }
}
