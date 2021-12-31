namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userporjver2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProjects", "EnrolledDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProjects", "EnrolledDate", c => c.DateTime(nullable: false));
        }
    }
}
