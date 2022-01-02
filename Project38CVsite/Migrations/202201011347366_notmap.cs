namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notmap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary());
            DropColumn("dbo.AspNetUsers", "ImagePath");
        }
    }
}
