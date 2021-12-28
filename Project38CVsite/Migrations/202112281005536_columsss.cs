namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Education", c => c.String());
            AddColumn("dbo.AspNetUsers", "Skill", c => c.String());
            AddColumn("dbo.AspNetUsers", "Experience", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsPrivate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsPrivate");
            DropColumn("dbo.AspNetUsers", "Experience");
            DropColumn("dbo.AspNetUsers", "Skill");
            DropColumn("dbo.AspNetUsers", "Education");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
