namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CourseId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CourseId", c => c.Int(nullable: false));
        }
    }
}
