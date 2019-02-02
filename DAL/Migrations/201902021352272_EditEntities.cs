namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "AddressId", c => c.Int());
            AddColumn("dbo.Teachers", "Email", c => c.String());
            CreateIndex("dbo.Students", "AddressId");
            AddForeignKey("dbo.Students", "AddressId", "dbo.Addresses", "Id");
            DropColumn("dbo.Students", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Adress", c => c.String(maxLength: 60));
            DropForeignKey("dbo.Students", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Students", new[] { "AddressId" });
            DropColumn("dbo.Teachers", "Email");
            DropColumn("dbo.Students", "AddressId");
            DropColumn("dbo.Students", "Email");
            DropTable("dbo.Addresses");
        }
    }
}
