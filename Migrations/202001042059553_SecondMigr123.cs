namespace Site_Lab12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigr123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Author");
        }
    }
}
