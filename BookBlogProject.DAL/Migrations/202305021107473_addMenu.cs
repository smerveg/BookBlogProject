namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        MenuStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
