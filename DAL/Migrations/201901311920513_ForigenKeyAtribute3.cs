namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForigenKeyAtribute3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PresetStudents", "StudentId", c => c.Int());
            CreateIndex("dbo.PresetStudents", "StudentId");
            AddForeignKey("dbo.PresetStudents", "StudentId", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PresetStudents", "StudentId", "dbo.Students");
            DropIndex("dbo.PresetStudents", new[] { "StudentId" });
            DropColumn("dbo.PresetStudents", "StudentId");
        }
    }
}
