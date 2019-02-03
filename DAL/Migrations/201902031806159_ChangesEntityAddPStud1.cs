namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesEntityAddPStud1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PresetStudents", "ConcreteLessonId", c => c.Int());
            CreateIndex("dbo.PresetStudents", "ConcreteLessonId");
            AddForeignKey("dbo.PresetStudents", "ConcreteLessonId", "dbo.ConcreteLessons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresetStudents", "ConcreteLessonId", "dbo.ConcreteLessons");
            DropIndex("dbo.PresetStudents", new[] { "ConcreteLessonId" });
            DropColumn("dbo.PresetStudents", "ConcreteLessonId");
        }
    }
}
