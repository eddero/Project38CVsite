namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FromUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "FromUserId");
            AddForeignKey("dbo.Messages", "FromUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Messages", "FromUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FromUser", c => c.String());
            DropForeignKey("dbo.Messages", "FromUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "FromUserId" });
            DropColumn("dbo.Messages", "FromUserId");
        }
    }
}
