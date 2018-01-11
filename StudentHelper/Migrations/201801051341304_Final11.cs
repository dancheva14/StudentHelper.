namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Specialty_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Students", "University_UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Grades", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Specialties", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "University_UniversityId", "dbo.Universities");
            DropIndex("dbo.Grades", new[] { "Student_StudentId" });
            DropIndex("dbo.Specialties", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Students", new[] { "Specialty_SpecialtyId" });
            DropIndex("dbo.Students", new[] { "University_UniversityId" });
            DropIndex("dbo.Teachers", new[] { "University_UniversityId" });
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        PersonInformation = c.String(),
                        EducationType = c.Int(nullable: false),
                        IsTeacher = c.Boolean(nullable: false),
                        University_UniversityId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Universities", t => t.University_UniversityId)
                .Index(t => t.University_UniversityId);
            
            AddColumn("dbo.Grades", "Person_PersonId", c => c.Int());
            AddColumn("dbo.Specialties", "Person_PersonId", c => c.Int());
            CreateIndex("dbo.Grades", "Person_PersonId");
            CreateIndex("dbo.Specialties", "Person_PersonId");
            AddForeignKey("dbo.Specialties", "Person_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Grades", "Person_PersonId", "dbo.People", "PersonId");
            DropColumn("dbo.Grades", "Student_StudentId");
            DropColumn("dbo.Specialties", "Teacher_TeacherId");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        PersonInformation = c.String(),
                        EducationType = c.Int(nullable: false),
                        Specialty_SpecialtyId = c.Int(),
                        University_UniversityId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            AddColumn("dbo.Specialties", "Teacher_TeacherId", c => c.Int());
            AddColumn("dbo.Grades", "Student_StudentId", c => c.Int());
            DropForeignKey("dbo.Grades", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "University_UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Specialties", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Specialties", new[] { "Person_PersonId" });
            DropIndex("dbo.People", new[] { "University_UniversityId" });
            DropIndex("dbo.Grades", new[] { "Person_PersonId" });
            DropColumn("dbo.Specialties", "Person_PersonId");
            DropColumn("dbo.Grades", "Person_PersonId");
            DropTable("dbo.People");
            CreateIndex("dbo.Teachers", "University_UniversityId");
            CreateIndex("dbo.Students", "University_UniversityId");
            CreateIndex("dbo.Students", "Specialty_SpecialtyId");
            CreateIndex("dbo.Specialties", "Teacher_TeacherId");
            CreateIndex("dbo.Grades", "Student_StudentId");
            AddForeignKey("dbo.Teachers", "University_UniversityId", "dbo.Universities", "UniversityId");
            AddForeignKey("dbo.Specialties", "Teacher_TeacherId", "dbo.Teachers", "TeacherId");
            AddForeignKey("dbo.Grades", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Students", "University_UniversityId", "dbo.Universities", "UniversityId");
            AddForeignKey("dbo.Students", "Specialty_SpecialtyId", "dbo.Specialties", "SpecialtyId");
        }
    }
}
