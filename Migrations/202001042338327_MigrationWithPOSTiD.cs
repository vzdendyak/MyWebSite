namespace Site_Lab12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationWithPOSTiD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "post_Id" });
            DropColumn("dbo.Comments", "PostId");
            RenameColumn(table: "dbo.Comments", name: "post_Id", newName: "PostId");
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            AlterColumn("dbo.Comments", "PostId", c => c.Int());
            AlterColumn("dbo.Comments", "PostId", c => c.String());
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "post_Id");
            AddColumn("dbo.Comments", "PostId", c => c.String());
            CreateIndex("dbo.Comments", "post_Id");
            AddForeignKey("dbo.Comments", "post_Id", "dbo.Posts", "Id");
        }
    }
}
