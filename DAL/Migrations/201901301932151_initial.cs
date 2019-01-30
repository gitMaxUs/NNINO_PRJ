namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        BirthDate = c.String(),
                        PhoneNumber = c.String(),
                        PerentPhoneNumber = c.String(),
                        Adress = c.String(),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConcreteLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Them = c.String(),
                        LessonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PresetStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentWasNotOnTheLesson = c.Boolean(nullable: false),
                        StudentSick = c.Boolean(nullable: false),
                        StudentHasReason = c.Boolean(nullable: false),
                        StudentNotPressent = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Id", "dbo.Lessons");
            DropForeignKey("dbo.ConcreteLessons", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropIndex("dbo.Teachers", new[] { "Id" });
            DropIndex("dbo.ConcreteLessons", new[] { "LessonId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropTable("dbo.PresetStudents");
            DropTable("dbo.Teachers");
            DropTable("dbo.ConcreteLessons");
            DropTable("dbo.Lessons");
            DropTable("dbo.Students");
            DropTable("dbo.Groups");
        }
    }
}
