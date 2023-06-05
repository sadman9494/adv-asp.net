namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        modelName = c.String(),
                        brandName = c.String(),
                        published = c.DateTime(nullable: false),
                        total = c.Int(nullable: false),
                        makeName = c.String(),
                        scale = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        uname = c.String(),
                        address = c.String(),
                        phone = c.String(),
                        totalCar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCars",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Cars_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Cars_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Cars_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Cars_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCars", "Cars_Id", "dbo.Cars");
            DropForeignKey("dbo.UserCars", "User_Id", "dbo.Users");
            DropIndex("dbo.UserCars", new[] { "Cars_Id" });
            DropIndex("dbo.UserCars", new[] { "User_Id" });
            DropTable("dbo.UserCars");
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}
