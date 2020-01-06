namespace Site_Lab12.Migrations.MessagesContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ITryNow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserFirstId = c.String(),
                        UserSecondId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        UserSenderId = c.String(),
                        UserToSendId = c.String(),
                        ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .Index(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMessages", "ChatId", "dbo.Chats");
            DropIndex("dbo.UserMessages", new[] { "ChatId" });
            DropTable("dbo.UserMessages");
            DropTable("dbo.Chats");
        }
    }
}
