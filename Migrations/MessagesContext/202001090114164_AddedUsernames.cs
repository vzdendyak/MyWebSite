namespace Site_Lab12.Migrations.MessagesContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUsernames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMessages", "senderUserName", c => c.String());
            AddColumn("dbo.UserMessages", "toSendUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMessages", "toSendUserName");
            DropColumn("dbo.UserMessages", "senderUserName");
        }
    }
}
