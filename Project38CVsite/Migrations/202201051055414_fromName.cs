namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fromName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FromName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "FromName");
        }
    }
}
