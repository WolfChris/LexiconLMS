namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class documents_deadline_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Deadline", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Deadline", c => c.DateTime(nullable: false));
        }
    }
}
