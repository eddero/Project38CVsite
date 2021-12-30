namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ManagerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Projects", "ManagerId");
            AddForeignKey("dbo.Projects", "ManagerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ManagerId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ManagerId" });
            DropColumn("dbo.Projects", "ManagerId");
        }
    }
}
