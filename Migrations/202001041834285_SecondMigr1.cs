namespace Site_Lab12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BodyText = c.String(),
                        AuthorId = c.String(),
                        PostId = c.String(),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
