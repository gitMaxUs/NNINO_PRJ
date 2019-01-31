namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NEWentitysProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConcreteLessons", "Description", c => c.String());
            DropColumn("dbo.ConcreteLessons", "Them");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConcreteLessons", "Them", c => c.String());
            DropColumn("dbo.ConcreteLessons", "Description");
        }
    }
}
