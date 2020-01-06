namespace Site_Lab12.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ITryNow0 : DbMigration
    {
        public override void Up()
        {




            AddColumn("dbo.AspNetUsers", "ChatId", c => c.Int(nullable: true));
            CreateIndex("dbo.AspNetUsers", "ChatId");
            AddForeignKey("dbo.AspNetUsers", "ChatId", "dbo.Chats", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ChatId", "dbo.Chats");

            DropIndex("dbo.AspNetUsers", new[] { "ChatId" });
            DropColumn("dbo.AspNetUsers", "ChatId");

        }
    }
}
