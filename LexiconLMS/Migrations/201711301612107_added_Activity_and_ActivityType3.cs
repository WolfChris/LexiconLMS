namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Activity_and_ActivityType3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        ActivityStart = c.DateTime(nullable: false),
                        ActivityEnd = c.DateTime(nullable: false),
                        ActivityDescription = c.String(),
                        ActivityTypeId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityTypes", t => t.ActivityTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ActivityTypeId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityTypeName = c.String(),
                        ActivityTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "CourseId" });
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.Activities");
        }
    }
}
