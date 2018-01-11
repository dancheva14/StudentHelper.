namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Students", "UniversityId");
            CreateIndex("dbo.Students", "SpecialtyId");
            AddForeignKey("dbo.Students", "SpecialtyId", "dbo.Specialties", "SpecialtyId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "UniversityId", "dbo.Universities", "UniversityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Students", "SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Students", new[] { "SpecialtyId" });
            DropIndex("dbo.Students", new[] { "UniversityId" });
        }
    }
}
