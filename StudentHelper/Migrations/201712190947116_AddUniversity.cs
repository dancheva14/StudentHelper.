namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniversity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        SpecialtyId = c.Int(nullable: false, identity: true),
                        SpecialtyName = c.String(),
                        UniversityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        UniversityId = c.Int(nullable: false, identity: true),
                        UniversityName = c.String(),
                    })
                .PrimaryKey(t => t.UniversityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Universities");
            DropTable("dbo.Specialties");
        }
    }
}
