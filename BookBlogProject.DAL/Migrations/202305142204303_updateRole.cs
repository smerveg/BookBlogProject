namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "RoleCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "RoleCode");
        }
    }
}
