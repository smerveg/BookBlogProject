namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteMenu : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Menus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        MenuURL = c.String(),
                        MenuStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
        }
    }
}
