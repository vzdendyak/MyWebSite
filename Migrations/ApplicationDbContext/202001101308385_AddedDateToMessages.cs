namespace Site_Lab12.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToMessages : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMessages", "Date");
        }
    }
}
