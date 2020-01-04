namespace Site_Lab12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigr1231 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "post_Id", c => c.Int());
            CreateIndex("dbo.Comments", "post_Id");
            AddForeignKey("dbo.Comments", "post_Id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "post_Id" });
            DropColumn("dbo.Comments", "post_Id");
        }
    }
}
