namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BookID", "dbo.Books");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "PersonID", "dbo.People");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "BookID" });
            DropIndex("dbo.Posts", new[] { "PersonID" });
            DropColumn("dbo.Posts", "CategoryID");
            DropColumn("dbo.Posts", "BookID");
            DropColumn("dbo.Posts", "PersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PersonID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "BookID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "PersonID");
            CreateIndex("dbo.Posts", "BookID");
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "BookID", "dbo.Books", "BookID");
        }
    }
}
