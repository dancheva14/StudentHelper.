namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Students", "UniversityId", "dbo.Universities");
            DropIndex("dbo.Students", new[] { "UniversityId" });
            DropIndex("dbo.Students", new[] { "SpecialtyId" });
            RenameColumn(table: "dbo.Students", name: "SpecialtyId", newName: "Specialty_SpecialtyId");
            RenameColumn(table: "dbo.Students", name: "UniversityId", newName: "University_UniversityId");
            AddColumn("dbo.Specialties", "University_UniversityId", c => c.Int());
            AlterColumn("dbo.Students", "University_UniversityId", c => c.Int());
            AlterColumn("dbo.Students", "Specialty_SpecialtyId", c => c.Int());
            CreateIndex("dbo.Specialties", "University_UniversityId");
            CreateIndex("dbo.Students", "Specialty_SpecialtyId");
            CreateIndex("dbo.Students", "University_UniversityId");
            AddForeignKey("dbo.Specialties", "University_UniversityId", "dbo.Universities", "UniversityId");
            AddForeignKey("dbo.Students", "Specialty_SpecialtyId", "dbo.Specialties", "SpecialtyId");
            AddForeignKey("dbo.Students", "University_UniversityId", "dbo.Universities", "UniversityId");
            DropColumn("dbo.Specialties", "UniversityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialties", "UniversityId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "University_UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Students", "Specialty_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Specialties", "University_UniversityId", "dbo.Universities");
            DropIndex("dbo.Students", new[] { "University_UniversityId" });
            DropIndex("dbo.Students", new[] { "Specialty_SpecialtyId" });
            DropIndex("dbo.Specialties", new[] { "University_UniversityId" });
            AlterColumn("dbo.Students", "Specialty_SpecialtyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "University_UniversityId", c => c.Int(nullable: false));
            DropColumn("dbo.Specialties", "University_UniversityId");
            RenameColumn(table: "dbo.Students", name: "University_UniversityId", newName: "UniversityId");
            RenameColumn(table: "dbo.Students", name: "Specialty_SpecialtyId", newName: "SpecialtyId");
            CreateIndex("dbo.Students", "SpecialtyId");
            CreateIndex("dbo.Students", "UniversityId");
            AddForeignKey("dbo.Students", "UniversityId", "dbo.Universities", "UniversityId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "SpecialtyId", "dbo.Specialties", "SpecialtyId", cascadeDelete: true);
        }
    }
}
