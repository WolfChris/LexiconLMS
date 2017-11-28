namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nav : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Modul_Id", "dbo.Moduls");
            DropIndex("dbo.Courses", new[] { "Modul_Id" });
            AddColumn("dbo.Moduls", "Courseid", c => c.Int(nullable: false));
            CreateIndex("dbo.Moduls", "Courseid");
            AddForeignKey("dbo.Moduls", "Courseid", "dbo.Courses", "CourseId", cascadeDelete: true);
            DropColumn("dbo.Courses", "Modul_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Modul_Id", c => c.Int());
            DropForeignKey("dbo.Moduls", "Courseid", "dbo.Courses");
            DropIndex("dbo.Moduls", new[] { "Courseid" });
            DropColumn("dbo.Moduls", "Courseid");
            CreateIndex("dbo.Courses", "Modul_Id");
            AddForeignKey("dbo.Courses", "Modul_Id", "dbo.Moduls", "Id");
        }
    }
}
