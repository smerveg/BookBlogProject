namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "MenuURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "MenuURL");
        }
    }
}
