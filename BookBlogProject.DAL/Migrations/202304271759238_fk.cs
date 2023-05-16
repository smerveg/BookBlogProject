namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BookID", "dbo.Books");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "PersonID", "dbo.People");
            AddForeignKey("dbo.Posts", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PersonID", "dbo.People");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "BookID", "dbo.Books");
            AddForeignKey("dbo.Posts", "PersonID", "dbo.People", "PersonID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.Posts", "BookID", "dbo.Books", "BookID");
        }
    }
}
