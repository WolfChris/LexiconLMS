namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentassigmentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAssigments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        FileName = c.String(),
                        ModulId = c.Int(),
                        ActivityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .ForeignKey("dbo.Moduls", t => t.ModulId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ModulId)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAssigments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentAssigments", "ModulId", "dbo.Moduls");
            DropForeignKey("dbo.StudentAssigments", "ActivityId", "dbo.Activities");
            DropIndex("dbo.StudentAssigments", new[] { "ActivityId" });
            DropIndex("dbo.StudentAssigments", new[] { "ModulId" });
            DropIndex("dbo.StudentAssigments", new[] { "UserId" });
            DropTable("dbo.StudentAssigments");
        }
    }
}
