namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altered_Activitycs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "CourseId", "dbo.Courses");
            DropIndex("dbo.Activities", new[] { "CourseId" });
            AddColumn("dbo.Activities", "ModuleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "ModuleId");
            AddForeignKey("dbo.Activities", "ModuleId", "dbo.Moduls", "Id", cascadeDelete: true);
            DropColumn("dbo.Activities", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Activities", "ModuleId", "dbo.Moduls");
            DropIndex("dbo.Activities", new[] { "ModuleId" });
            DropColumn("dbo.Activities", "ModuleId");
            CreateIndex("dbo.Activities", "CourseId");
            AddForeignKey("dbo.Activities", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
