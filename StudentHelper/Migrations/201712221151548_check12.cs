namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Universities", "Location", c => c.String());
            AddColumn("dbo.Universities", "Site", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Universities", "Site");
            DropColumn("dbo.Universities", "Location");
        }
    }
}
