namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TeacherPositionAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Position");
        }
    }
}
