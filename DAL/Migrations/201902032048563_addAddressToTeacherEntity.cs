namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressToTeacherEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConcreteLessons", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ConcreteLessons", "teacherId", c => c.Int());
            AddColumn("dbo.Teachers", "AddressId", c => c.Int());
            CreateIndex("dbo.ConcreteLessons", "teacherId");
            CreateIndex("dbo.Teachers", "AddressId");
            AddForeignKey("dbo.Teachers", "AddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.ConcreteLessons", "teacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConcreteLessons", "teacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Teachers", new[] { "AddressId" });
            DropIndex("dbo.ConcreteLessons", new[] { "teacherId" });
            DropColumn("dbo.Teachers", "AddressId");
            DropColumn("dbo.ConcreteLessons", "teacherId");
            DropColumn("dbo.ConcreteLessons", "Date");
        }
    }
}
