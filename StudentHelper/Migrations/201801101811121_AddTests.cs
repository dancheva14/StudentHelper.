namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "Specialty_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Grades", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Grades", "Specialty_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Exams", new[] { "Specialty_SpecialtyId" });
            DropIndex("dbo.Grades", new[] { "Person_PersonId" });
            DropIndex("dbo.Grades", new[] { "Specialty_SpecialtyId" });
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        TestResultId = c.Int(nullable: false, identity: true),
                        CorrectAnswers = c.Int(nullable: false),
                        WrongAnswers = c.Int(nullable: false),
                        EmptyAnswers = c.Int(nullable: false),
                        Procent = c.Int(nullable: false),
                        Status = c.String(),
                        Grade = c.String(),
                        Date = c.DateTime(nullable: false),
                        Person_PersonId = c.Int(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TestResultId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Points = c.Double(nullable: false),
                        ExamType = c.Int(nullable: false),
                        Specialty_SpecialtyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.Specialty_SpecialtyId)
                .Index(t => t.Specialty_SpecialtyId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Comment = c.String(),
                        Answer = c.Int(nullable: false),
                        RightAnswerIndex = c.Int(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            DropTable("dbo.Exams");
            DropTable("dbo.Grades");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeN = c.Int(nullable: false),
                        GradeName = c.String(),
                        Person_PersonId = c.Int(),
                        Specialty_SpecialtyId = c.Int(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamsId = c.Int(nullable: false, identity: true),
                        ExamType = c.Int(nullable: false),
                        ExamDate = c.DateTime(),
                        Hall = c.String(),
                        Specialty_SpecialtyId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamsId);
            
            DropForeignKey("dbo.TestResults", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Specialty_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TestResults", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            DropIndex("dbo.Tests", new[] { "Specialty_SpecialtyId" });
            DropIndex("dbo.TestResults", new[] { "Test_Id" });
            DropIndex("dbo.TestResults", new[] { "Person_PersonId" });
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.TestResults");
            CreateIndex("dbo.Grades", "Specialty_SpecialtyId");
            CreateIndex("dbo.Grades", "Person_PersonId");
            CreateIndex("dbo.Exams", "Specialty_SpecialtyId");
            AddForeignKey("dbo.Grades", "Specialty_SpecialtyId", "dbo.Specialties", "SpecialtyId");
            AddForeignKey("dbo.Grades", "Person_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Exams", "Specialty_SpecialtyId", "dbo.Specialties", "SpecialtyId");
        }
    }
}
