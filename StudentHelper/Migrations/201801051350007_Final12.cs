namespace StudentHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PersonName", c => c.String());
            DropColumn("dbo.People", "StudentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "StudentName", c => c.String());
            DropColumn("dbo.People", "PersonName");
        }
    }
}
