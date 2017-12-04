namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDocument_and_documenttype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        FileName = c.String(),
                        DocumentTypeId = c.Int(nullable: false),
                        CourseId = c.Int(),
                        ModulId = c.Int(),
                        ActivityId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Moduls", t => t.ModulId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.DocumentTypeId)
                .Index(t => t.CourseId)
                .Index(t => t.ModulId)
                .Index(t => t.ActivityId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentTypeName = c.String(),
                        DocumentTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "ModulId", "dbo.Moduls");
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.Documents", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Documents", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Documents", new[] { "User_Id" });
            DropIndex("dbo.Documents", new[] { "ActivityId" });
            DropIndex("dbo.Documents", new[] { "ModulId" });
            DropIndex("dbo.Documents", new[] { "CourseId" });
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
        }
    }
}
