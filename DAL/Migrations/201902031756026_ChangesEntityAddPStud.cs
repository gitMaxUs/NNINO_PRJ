namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesEntityAddPStud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProblemStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            AddColumn("dbo.PresetStudents", "CountOfSkippedClasses", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProblemStudents", "StudentId", "dbo.Students");
            DropIndex("dbo.ProblemStudents", new[] { "StudentId" });
            DropColumn("dbo.PresetStudents", "CountOfSkippedClasses");
            DropTable("dbo.ProblemStudents");
        }
    }
}
