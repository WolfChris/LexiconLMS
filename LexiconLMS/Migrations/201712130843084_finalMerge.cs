namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalMerge : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Image", c => c.Binary());
        }
    }
}
