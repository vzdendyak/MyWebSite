namespace Site_Lab12.Migrations.MessagesContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMessages", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMessages", "Date");
        }
    }
}
