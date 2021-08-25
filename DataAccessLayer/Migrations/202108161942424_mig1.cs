namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(maxLength: 1000),
                        AboutDetails2 = c.String(maxLength: 1000),
                        AboutImage1 = c.String(maxLength: 100),
                        AboutImage2 = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 50),
                        AuthorSurname = c.String(maxLength: 50),
                        AuthorImage = c.String(maxLength: 100),
                        AuthorMail = c.String(maxLength: 50),
                        AuthorPassword = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentText = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        HeadingId = c.Int(nullable: false),
                        AuthorID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .ForeignKey("dbo.Headings", t => t.HeadingId, cascadeDelete: true)
                .Index(t => t.HeadingId)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingId = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 100),
                        HeadingDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingId)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(maxLength: 200),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Headings", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Contents", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Headings", new[] { "AuthorID" });
            DropIndex("dbo.Headings", new[] { "CategoryID" });
            DropIndex("dbo.Contents", new[] { "AuthorID" });
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.Headings");
            DropTable("dbo.Contents");
            DropTable("dbo.Authors");
            DropTable("dbo.Abouts");
        }
    }
}
