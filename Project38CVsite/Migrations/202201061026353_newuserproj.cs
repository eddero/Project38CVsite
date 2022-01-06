namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newuserproj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserProjects", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.UserProject",
                c => new
                    {
                        ProjectRefId = c.Int(nullable: false),
                        UserRefId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjectRefId, t.UserRefId })
                .ForeignKey("dbo.Projects", t => t.ProjectRefId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserRefId, cascadeDelete: true)
                .Index(t => t.ProjectRefId)
                .Index(t => t.UserRefId);
            
            DropTable("dbo.UserProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.ApplicationUserId });
            
            DropForeignKey("dbo.UserProject", "UserRefId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProject", "ProjectRefId", "dbo.Projects");
            DropIndex("dbo.UserProject", new[] { "UserRefId" });
            DropIndex("dbo.UserProject", new[] { "ProjectRefId" });
            DropTable("dbo.UserProject");
            CreateIndex("dbo.UserProjects", "ApplicationUserId");
            CreateIndex("dbo.UserProjects", "ProjectId");
            AddForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProjects", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
