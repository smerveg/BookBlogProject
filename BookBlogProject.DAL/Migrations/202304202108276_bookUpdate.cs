﻿namespace BookBlogProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
