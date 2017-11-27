namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModulTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moduls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModulName = c.String(),
                        ModulDescription = c.String(),
                        ModulStart = c.DateTime(nullable: false),
                        ModulEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "Modul_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Modul_Id");
            AddForeignKey("dbo.Courses", "Modul_Id", "dbo.Moduls", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Modul_Id", "dbo.Moduls");
            DropIndex("dbo.Courses", new[] { "Modul_Id" });
            DropColumn("dbo.Courses", "Modul_Id");
            DropTable("dbo.Moduls");
        }
    }
}
