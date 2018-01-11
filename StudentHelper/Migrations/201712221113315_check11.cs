namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
            AddColumn("dbo.Students", "PersonInformation", c => c.String());
            AddColumn("dbo.Students", "EducationType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "EducationType");
            DropColumn("dbo.Students", "PersonInformation");
            DropColumn("dbo.Students", "PhoneNumber");
            DropColumn("dbo.Students", "Email");
        }
    }
}
