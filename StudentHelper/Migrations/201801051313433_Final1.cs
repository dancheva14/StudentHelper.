namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeN = c.Int(nullable: false),
                        GradeName = c.String(),
                        Specialty_SpecialtyId = c.Int(),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Specialties", t => t.Specialty_SpecialtyId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Specialty_SpecialtyId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        PersonInformation = c.String(),
                        EducationType = c.Int(nullable: false),
                        University_UniversityId = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Universities", t => t.University_UniversityId)
                .Index(t => t.University_UniversityId);
            
            AddColumn("dbo.Specialties", "Teacher_TeacherId", c => c.Int());
            CreateIndex("dbo.Specialties", "Teacher_TeacherId");
            AddForeignKey("dbo.Specialties", "Teacher_TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "University_UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Specialties", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Grades", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "Specialty_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Teachers", new[] { "University_UniversityId" });
            DropIndex("dbo.Specialties", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Grades", new[] { "Student_StudentId" });
            DropIndex("dbo.Grades", new[] { "Specialty_SpecialtyId" });
            DropColumn("dbo.Specialties", "Teacher_TeacherId");
            DropTable("dbo.Teachers");
            DropTable("dbo.Grades");
        }
    }
}
