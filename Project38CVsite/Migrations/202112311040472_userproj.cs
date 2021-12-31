namespace Project38CVsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userproj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserProjects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserProjects", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ApplicationUserProjects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserProjects", new[] { "Project_Id" });
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        EnrolledDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.ApplicationUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ApplicationUserId);
            
            DropTable("dbo.ApplicationUserProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserProjects",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Project_Id });
            
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserProjects", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropTable("dbo.UserProjects");
            CreateIndex("dbo.ApplicationUserProjects", "Project_Id");
            CreateIndex("dbo.ApplicationUserProjects", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserProjects", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserProjects", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
