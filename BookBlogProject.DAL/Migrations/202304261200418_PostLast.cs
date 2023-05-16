namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryID");
            CreateIndex("dbo.Posts", "BookID");
            CreateIndex("dbo.Posts", "PersonID");
            AddForeignKey("dbo.Posts", "BookID", "dbo.Books", "BookID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "PersonID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PersonID", "dbo.People");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "BookID", "dbo.Books");
            DropIndex("dbo.Posts", new[] { "PersonID" });
            DropIndex("dbo.Posts", new[] { "BookID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropColumn("dbo.Posts", "PersonID");
            DropColumn("dbo.Posts", "BookID");
            DropColumn("dbo.Posts", "CategoryID");
        }
    }
}
