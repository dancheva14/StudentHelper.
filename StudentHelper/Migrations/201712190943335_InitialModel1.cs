namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UniversityId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "SpecialtyId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "University");
            DropColumn("dbo.Students", "Specialty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Specialty", c => c.String());
            AddColumn("dbo.Students", "University", c => c.String());
            DropColumn("dbo.Students", "SpecialtyId");
            DropColumn("dbo.Students", "UniversityId");
        }
    }
}
