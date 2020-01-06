namespace Site_Lab12.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ITryNow09 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ChatId", "dbo.Chats");
            DropIndex("dbo.AspNetUsers", new[] { "ChatId" });
            AlterColumn("dbo.AspNetUsers", "ChatId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "ChatId");
            AddForeignKey("dbo.AspNetUsers", "ChatId", "dbo.Chats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ChatId", "dbo.Chats");
            DropIndex("dbo.AspNetUsers", new[] { "ChatId" });
            AlterColumn("dbo.AspNetUsers", "ChatId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ChatId");
            AddForeignKey("dbo.AspNetUsers", "ChatId", "dbo.Chats", "Id", cascadeDelete: true);
        }
    }
}
