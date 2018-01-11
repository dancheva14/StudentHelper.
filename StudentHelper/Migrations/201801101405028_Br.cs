namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Br : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ExamsId)
                .ForeignKey("dbo.Specialties", t => t.Specialty_SpecialtyId)
                .Index(t => t.Specialty_SpecialtyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "Specialty_SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Exams", new[] { "Specialty_SpecialtyId" });
            DropTable("dbo.Exams");
        }
    }
}
