namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Mail", c => c.Int(nullable: false));
        }
    }
}
