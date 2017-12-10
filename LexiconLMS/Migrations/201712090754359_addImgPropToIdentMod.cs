namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImgPropToIdentMod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Image");
        }
    }
}
