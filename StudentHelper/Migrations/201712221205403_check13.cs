namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specialties", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialties", "Description");
        }
    }
}
