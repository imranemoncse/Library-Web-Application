namespace LibraryManagementSystem.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        AuthorName = c.String(nullable: false, maxLength: 150),
                        Quantity = c.Int(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DayFor = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsReturn = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        Email = c.String(),
                        Contact = c.String(nullable: false),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Orders", "BookID", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "BookID" });
            DropIndex("dbo.Orders", new[] { "StudentID" });
            DropTable("dbo.Users");
            DropTable("dbo.Students");
            DropTable("dbo.Orders");
            DropTable("dbo.Books");
        }
    }
}
