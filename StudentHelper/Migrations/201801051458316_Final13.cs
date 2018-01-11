namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.People", "IsTeacher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "IsTeacher", c => c.Boolean(nullable: false));
            DropColumn("dbo.People", "Type");
        }
    }
}
