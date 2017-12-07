namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_field_courseid_to_users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CourseId");
        }
    }
}
